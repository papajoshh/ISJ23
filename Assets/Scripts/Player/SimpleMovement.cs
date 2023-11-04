using Core;
using UnityEngine;

namespace Player
{
    public class SimpleMovement : MonoBehaviour
    {
        private Vector2 movement;
        
        [Header("Components")]
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private Animator dayAnim;
        [SerializeField] private GameObject dayPlayer;
        [SerializeField] private Animator nigthAnim;
        [SerializeField] private GameObject nigthPlayer;
        
        [Header("Values")]
        public float speed;
        public float normalSpeed;
        [SerializeField] private float runAccelAmount;
        [SerializeField] private float runDeccelAmount;
        [SerializeField] private bool isDay;

        [HideInInspector]
        public Vector2 faceDirection;
        #region Unity Events
        private void Start()
        {
            normalSpeed = speed;
        }
        // Update is called once per frame
        void Update()
        {
            if (IsPlaying())
            {
                PlayerInputsValues();
            }
            PlayerAnimationController();
        }

        private void FixedUpdate()
        {
            if (IsPlaying())
            {
                PlayerMove();
            }
            else
            {
                ResetMovement();
            }
        }

        
        #endregion

        private void PlayerInputsValues()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            CheckFaceDirection();
        }

        private void PlayerMove()
        {
            Vector2 accelRate = GetAccelRate(GetTargetSpeed());
            Vector2 speedDif = GetSpeedDif(GetTargetSpeed());
            Vector2 rate = GetRate(accelRate, speedDif);

            rb2d.AddForce(rate, ForceMode2D.Force);
        }
        private Vector2 GetTargetSpeed()
        {
            return new Vector2(movement.x, movement.y).normalized * speed;
        }
        private Vector2 GetAccelRate(Vector2 targetSpeed)
        {
            float xAcceleration = (Mathf.Abs(targetSpeed.x) > 0.01f) ? runAccelAmount : runDeccelAmount;
            float yAcceleration = (Mathf.Abs(targetSpeed.y) > 0.01f) ? runAccelAmount : runDeccelAmount;
            return new Vector2(xAcceleration, yAcceleration);
        }
        private Vector2 GetSpeedDif(Vector2 targetSpeed)
        {
            return new Vector2(targetSpeed.x - rb2d.velocity.x, targetSpeed.y - rb2d.velocity.y);
        }
        private static Vector2 GetRate(Vector2 accelRate, Vector2 speedDif)
        {
            return new Vector2(speedDif.x * accelRate.x, speedDif.y * accelRate.y);
        }

        private void ResetMovement()
        {
            rb2d.velocity = Vector2.zero;
            movement = Vector2.zero;//Temporal
        }
        private void CheckFaceDirection()
        {
            if (PlayerIsMoving())
            {
                faceDirection.x = movement.x;
                faceDirection.y = movement.y;
            }

        }

        private bool PlayerIsMoving()
        {
            return movement.magnitude != 0;
        }

        private void PlayerAnimation(Animator animator)
        {
            if (PlayerIsMoving())
            {
                SetFloatAnimator(animator, "Horizontal", movement.x);
                SetFloatAnimator(animator, "Vertical", movement.y);
                PlayAnim(animator, "Movement");
            }
            else
            {
                PlayAnim(animator, "IdleBlend");
            }
        }

        private static void PlayAnim(Animator animator, string _clipAnimation)
        {
            animator.Play(_clipAnimation);
        }

        private void SetFloatAnimator(Animator animator, string _label, float _value)
        {
            animator.SetFloat(_label, _value);
        }

        private void PlayerAnimationController()
        {
            Animator animToPlay = GetPlayerAnimator(isDay);
            PlayerAnimation(animToPlay);
            ActivatePlayer(isDay);
        }

        private void ActivatePlayer(bool _isDay)
        {
            dayPlayer.SetActive(_isDay);
            nigthPlayer.SetActive(!_isDay);
        }

        private Animator GetPlayerAnimator(bool _isDay)
        {
            if (_isDay)
            {
                return dayAnim;
            }
            else
            {
                return nigthAnim;
            }
        }

        public void ChangePlayerSprite()
        {
            isDay =! isDay;
        }

        private static bool IsPlaying()
        {
            return GameStateController.Instance.gameState == GameStateController.GameState.Gameplay;
        }

    }
}
