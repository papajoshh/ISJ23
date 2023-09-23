using System;
using UnityEngine;

namespace Player
{
    public class PlayerRunSkill : MonoBehaviour
    {

        [SerializeField] private SimpleMovement playerMovement;
        [SerializeField] private float runSpeed;

        [Header("Particle")] [SerializeField] 
        private ParticleSystem sweatParticle;
        
        [Header("Animator")] 
        [SerializeField] private Animator animator;
        [SerializeField] private Animator nightAnimator;
        
        private float timePlayerCanSprint;
        private float TimePlayerCanSprint
        {
            get => timePlayerCanSprint;
            set => timePlayerCanSprint = Mathf.Max(value, 0);
        }
        [SerializeField] private float sprintCooldown;

        private bool canSprint;
        public bool isOnMug;
        
        private void Start()
        {
            canSprint = true;
        }

        private void Update()
        {
            SprintSkill();

            if (TimePlayerCanSprint >= sprintCooldown)
            {
                canSprint = false;
                sweatParticle.Play();
            }
            else if (TimePlayerCanSprint <= 0)
            {
                TimePlayerCanSprint = 0;
                canSprint = true;
                sweatParticle.Stop();
            }
        }

        private void SprintSkill()
        {
            if (Input.GetKey(KeyCode.LeftShift) && TimePlayerCanSprint < sprintCooldown)
            {
                if (canSprint)
                {
                    animator.speed = 2f;
                    nightAnimator.speed = 2f;
                    TimePlayerCanSprint += Time.deltaTime;

                    if (isOnMug)
                        playerMovement.speed = runSpeed / 2;
                    else
                        playerMovement.speed = runSpeed;
                }

            }
            else//perdón
            {
                if (!isOnMug)
                {
                    animator.speed = 1f;
                    nightAnimator.speed = 1f;
                    playerMovement.speed = playerMovement.normalSpeed;
                    TimePlayerCanSprint -= Time.deltaTime;
                }
                else
                {
                    playerMovement.speed = 0.5f;
                    TimePlayerCanSprint -= Time.deltaTime;
                }
 
            }
        }
    }
}
