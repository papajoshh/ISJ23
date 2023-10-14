using System;
using Player;
using UnityEngine;

namespace Core
{
    public class MudTerrain : MonoBehaviour
    {
        [SerializeField] private SimpleMovement playerMove;
        [SerializeField] private Player_Sprint playerRunSkill;
        [SerializeField] private float mugSpeed;


        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //playerMove.normalSpeed = mugSpeed;
                playerMove.speed = mugSpeed;
                playerRunSkill.playerOnMud = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                playerMove.speed = playerMove.normalSpeed;
                playerRunSkill.playerOnMud = false;
            }
        }
    }
}
