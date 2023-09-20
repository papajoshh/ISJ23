using System;
using UnityEngine;

namespace Player
{
    public class PlayerRunSkill : MonoBehaviour
    {

        [SerializeField] private SimpleMovement playerMovement;
        [SerializeField] private float runSpeed;
        
        private float timePlayerCanSprint;
        private float TimePlayerCanSprint
        {
            get => timePlayerCanSprint;
            set => timePlayerCanSprint = Mathf.Max(value, 0);
        }
        [SerializeField] private float sprintCooldown;

        private bool canSprint;

        private void Start()
        {
            canSprint = true;
        }

        private void Update()
        {
            SprintSkill();
            Debug.Log(timePlayerCanSprint);

            if (TimePlayerCanSprint >= sprintCooldown)
            {
                canSprint = false;
            }
            else if (TimePlayerCanSprint <= 0)
            {
                TimePlayerCanSprint = 0;
                canSprint = true;
            }
        }

        private void SprintSkill()
        {
            if (Input.GetKey(KeyCode.LeftShift) && TimePlayerCanSprint < sprintCooldown)
            {
                if (canSprint)
                {
                    playerMovement.speed = runSpeed;
                    TimePlayerCanSprint += Time.deltaTime;
                }

            }
            else
            {
                playerMovement.speed = playerMovement.normalSpeed;
                TimePlayerCanSprint -= Time.deltaTime;
            }
        }
    }
}
