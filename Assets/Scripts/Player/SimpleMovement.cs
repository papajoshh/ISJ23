using System;
using Core;
using UnityEngine;

namespace Player
{
    public class SimpleMovement : MonoBehaviour
    {
        private Vector2 movement;

        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private float speed;
        [SerializeField] private float runAccelAmount;
        [SerializeField] private float runDeccelAmount;

        [Header("Test move with force")]
        public bool testMoveImprove;

        // Update is called once per frame
        void Update()
        {
            PlayerInputsValues();
        }

        private void FixedUpdate()
        {
            if (GameStateController.Instance.gameState == GameStateController.GameState.Gameplay)
            {
                CanMove();
            }
            else
            {
                rb2d.velocity = Vector2.zero;
            }

        }

        private void PlayerInputsValues()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        private void CanMove()
        {
            if (testMoveImprove)
            {
                PlayerMoveImprove();
            }
            else
            {
                PlayerMovement(speed);
            }
        }

        private void PlayerMovement(float s)
        {
            if (movement.x == 0 || movement.y == 0)
            {
                rb2d.velocity = Vector2.zero;
            }
            
            rb2d.MovePosition(rb2d.position + movement.normalized * (s * Time.fixedDeltaTime));
        }

        private void PlayerMoveImprove()
        {
            Vector2 targetSpeed = new Vector2(movement.x, movement.y) * speed;
            Vector2 accelRate = new Vector2((Mathf.Abs(targetSpeed.x) > 0.01f) ? runAccelAmount : runDeccelAmount,
                (Mathf.Abs(targetSpeed.y) > 0.01f) ? runAccelAmount : runDeccelAmount);
            Vector2 speedDif = new Vector2(targetSpeed.x - rb2d.velocity.x, targetSpeed.y - rb2d.velocity.y);
            Vector2 rate = new Vector2(speedDif.x * accelRate.x, speedDif.y * accelRate.y);
            
            rb2d.AddForce(rate, ForceMode2D.Force);
        }

        
    }
}
