using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace General
{
    public class RainController : MonoBehaviour
    {

        [SerializeField] private ParticleSystem rainParticle;

        private void Start()
        {
            rainParticle.Stop();
        }
        
        private void Update()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                rainParticle.Stop();
            }
            else if (StaticData.gamePhase >= 3)
            {
                rainParticle.Play();
            }
        }
    }
}
