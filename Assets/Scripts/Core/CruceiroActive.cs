using System;
using System.Collections;
using GameEventsTestJose;
using UnityEngine;

namespace Core
{
    public class CruceiroActive : MonoBehaviour
    {

        [SerializeField] private GameObject cruceiro;
        [SerializeField] private GameEvent cruceiroEvent;

        private void OnTriggerEnter2D(Collider2D col)
        {
            cruceiro.SetActive(true);
            cruceiroEvent.Raise();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            cruceiro.SetActive(false);
            cruceiroEvent.Raise();
        }
        
    }
}
