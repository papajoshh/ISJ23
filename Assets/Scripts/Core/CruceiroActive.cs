using System;
using System.Collections;
using GameEvents;
using UnityEngine;

namespace Core
{
    public class CruceiroActive : MonoBehaviour
    {
        
        [SerializeField] private GameEvent cruceiroEvent;
        [SerializeField] private bool onCruceiro = false;

        private void OnTriggerEnter2D(Collider2D col)
        {

        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && !onCruceiro)
            {
                Player_DropBread.instance.gameObject.GetComponent<Player.PlayerDead>().SetLastCruceiro(gameObject);
                cruceiroEvent.Raise();
                onCruceiro = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                cruceiroEvent.Raise();
                onCruceiro = false;
            }
        }
        
    }
}
