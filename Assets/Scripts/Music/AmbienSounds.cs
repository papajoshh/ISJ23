using System;
using UnityEngine;

namespace Music
{
    public class AmbienSounds : MonoBehaviour
    {

        [SerializeField] private AudioSource audioSource;
        
        private void OnEnable()
        {
            audioSource.Play();
        }

        private void OnDisable()
        {
            audioSource.Stop();
        }
    }
}
