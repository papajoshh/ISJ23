using System;
using UnityEngine;

namespace Player
{
    public class SimpleMovement : MonoBehaviour
    {
        private Vector2 movement;

        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private float speed;

        // Update is called once per frame
        void Update()
        {
            PlayerInputsValues();
        }

        private void FixedUpdate()
        {
            PlayerMovement(speed);
        }

        private void PlayerInputsValues()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        }

        private void PlayerMovement(float s)
        {
            rb2d.MovePosition(rb2d.position + movement * (s * Time.fixedDeltaTime));
        }
    }
}
