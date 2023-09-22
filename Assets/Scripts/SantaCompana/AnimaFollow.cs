using System;
using UnityEngine;
using UnityEngine.AI;

namespace SantaCompana
{
    public class AnimaFollow : MonoBehaviour
    {

        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform destination;

        private void Start()
        {
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        private void Update()
        {
            agent.SetDestination(destination.position);
        }
    }
}
