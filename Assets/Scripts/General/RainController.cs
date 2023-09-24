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

            if (Input.GetKeyDown(KeyCode.F3))
            {
                StaticData.gamePhase += 1;
            }
            
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                rainParticle.Stop();
            }
            else if (StaticData.gamePhase >= 2)
            {
                rainParticle.Play();
            }
        }
    }
}
