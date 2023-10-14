using System;
using UnityEngine;

namespace Player //No he usado namespaces, son recomendables? Para que sirven?
{
    public class Player_Sprint : MonoBehaviour
    {
        [Header("[References]")]
        [SerializeField] private AudioSource ExhaustAudiosource;
        [SerializeField] private Animator playerDayAnimator;
        [SerializeField] private Animator playerNightAnimator;
        [SerializeField] private SimpleMovement playerMovement;
        [SerializeField] private ParticleSystem sweatParticle;

        [Header("[Configuration]")]
        [SerializeField] private float sprintSpeed;
        [SerializeField] private float maxSprintTime;
        [SerializeField] private float playerTotalTimeSprinting;
        [SerializeField]
        private float playerSprintingTime //Se puede hacer el get/set con un solo campo?
        {
            get => playerTotalTimeSprinting;
            set => playerTotalTimeSprinting = Mathf.Max(value, 0);
        }

        [Header("[Values]")]
        [SerializeField] private bool isPlayerSprinting;
        [SerializeField] private bool isPlayerExhausted;
        public bool playerOnMud; //Esta clase no debería gestionar si el jugador está o no en el barro


        private void Update()
        {
            Check_IsPlayerSprinting();
            Check_SprintInput();
            Check_PlayerOnMud();

            Refresh_PlayerAnimation();
        }


        private void Check_SprintInput()
        {
            if (Input.GetKey(KeyCode.LeftShift) && !isPlayerExhausted)
                Player_Sprinting();
            else
                Player_Walking();
        }


        private void Player_Sprinting()
        {
            isPlayerSprinting = true;
            playerMovement.speed = sprintSpeed;
        }


        private void Player_Walking()
        {
            isPlayerSprinting = false;
            playerMovement.speed = playerMovement.normalSpeed;
        }


        private void Check_IsPlayerSprinting()
        {
            if (isPlayerSprinting)
                Increase_PlayerSprintingTime();
            else
                Decrease_PlayerSprintingTime();
        }


        private void Increase_PlayerSprintingTime()
        {
            playerSprintingTime += Time.deltaTime;
            Check_IsPlayerExhausted();
        }

        private void Decrease_PlayerSprintingTime()
        {
            playerSprintingTime -= Time.deltaTime;

            if (isPlayerExhausted && playerSprintingTime <= 0)
                Set_PlayerRecovered();
        }


        private void Check_IsPlayerExhausted()
        {
            if(playerSprintingTime > maxSprintTime)
                Set_PlayerExhausted();
        }


        private void Set_PlayerExhausted()
        {
            isPlayerExhausted = true;

            Show_SweatParticles(true);
            Play_ExhaustedSFX(true);
        }


        private void Set_PlayerRecovered()
        {
            isPlayerExhausted = false;
            playerSprintingTime = 0;

            Show_SweatParticles(false);
            Play_ExhaustedSFX(false);
        }


        private void Show_SweatParticles(bool showParticles)
        {
            if (showParticles)
                sweatParticle.Play();
            else
                sweatParticle.Stop();
        }


        private void Play_ExhaustedSFX(bool playSFX)
        {
            if (playSFX)
                ExhaustAudiosource.Play();
            else
                ExhaustAudiosource.Stop();
        }


        //Esta función debería ir en la clase que gestione el movimiento en general
        private void Check_PlayerOnMud() 
        {
            if (playerOnMud)
                playerMovement.speed /= 2;
        }


        //Esta función debería ir en una clase que gestione las distintas animaciones del jugador
        private void Refresh_PlayerAnimation()
        {
            playerDayAnimator.speed = isPlayerSprinting ? 2f : 1f;
            playerNightAnimator.speed = isPlayerSprinting ? 2f : 1f;
        }
    }
}
