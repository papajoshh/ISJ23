using System;
using UnityEngine;

namespace General
{
    public class RainController : MonoBehaviour
    {

        [SerializeField] private ParticleSystem particleSystem;


        private void Update()
        {
            if (StaticData.gamePhase >= 2)
            {
                particleSystem.Play();
            }
            else
            {
                particleSystem.Stop();
            }
        }
    }
}
