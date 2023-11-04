using UnityEngine;

namespace Player
{
    public class PlayerRunSkill : MonoBehaviour
    {
        public bool isOnMug;

        [SerializeField] private SimpleMovement playerMovement;
        [SerializeField] private float runSpeed;

        [Header("Particle")] [SerializeField] 
        private ParticleSystem sweatParticle;
        
        [Header("Components")] 
        [SerializeField] private Animator animator;
        [SerializeField] private Animator nightAnimator;
        [SerializeField] private AudioSource audioS;
        
        private float timePlayerCanSprint;
        private float TimePlayerCanSprint
        {
            get => timePlayerCanSprint;
            set => timePlayerCanSprint = Mathf.Max(value, 0);
        }
        [SerializeField] private float sprintCooldown;

        private bool canSprint;
        private bool soundOn;
        
        
        private void Start()
        {
            canSprint = true;
        }

        private void Update()
        {
            SprintSkill();
            canSprint = !SprintIsBlocked() && CanSprint();
            if (SprintIsBlocked())
            {
                sweatParticle.Play();
            }
            else if (CanSprint())
            {
                TimePlayerCanSprint = 0;
                sweatParticle.Stop();
                audioS.Stop();
            }

            ControlSound();
        }

        private bool CanSprint()
        {
            return TimePlayerCanSprint <= 0;
        }

        private bool SprintIsBlocked()
        {
            return TimePlayerCanSprint >= sprintCooldown;
        }

        
        private void ControlSound()
        {
            if (!canSprint)
            {
                if (soundOn)
                {
                    soundOn = false;
                    audioS.Play();
                }
            }
            else
            {
                audioS.Stop();
                soundOn = true;
            }
        }

        private void SprintSkill()
        {
            if (IsPressingSkillKey() && !SprintIsBlocked())
            {
                if (canSprint)
                {
                    RunSprintSkill();
                }
            }
            else//perdón
            {
                DoStandardRun();
            }
        }

        private void DoStandardRun()
        {
            if (!isOnMug)
            {
                SetAnimatorSpeed(1f);
            }
            SetPlayerMovementSpeed(GetSurfaceStandarSpeed());
            TimePlayerCanSprint -= Time.deltaTime;
        }

        private void RunSprintSkill()
        {
            SetAnimatorSpeed(2f);
            TimePlayerCanSprint += Time.deltaTime;
            SetPlayerMovementSpeed(GetSurfaceSprintSpeed());
        }

        private float GetSurfaceSprintSpeed()
        {
            float speedToSet;
            if (isOnMug)
                speedToSet = runSpeed / 2;
            else
                speedToSet = runSpeed;
            return speedToSet;
        }
        private float GetSurfaceStandarSpeed()
        {
            float speedToSet;
            if (!isOnMug)
            {
                speedToSet = playerMovement.normalSpeed;
            }
            else
            {
                speedToSet = 0.5f;
            }
            return speedToSet;
        }

        private static bool IsPressingSkillKey()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }

        private void SetPlayerMovementSpeed(float _speed)
        {
            playerMovement.speed = _speed;
        }

        private void SetAnimatorSpeed(float _speed)
        {
            animator.speed = _speed;
            nightAnimator.speed = _speed;
        }
    }
}
