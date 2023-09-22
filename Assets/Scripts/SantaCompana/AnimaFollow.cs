using System;
using UnityEngine;
using UnityEngine.AI;

namespace SantaCompana
{
    public class AnimaFollow : MonoBehaviour
    {

        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private NavMeshAgent destinyAgent;
        [SerializeField] private Transform destination;

        [SerializeField] private Animator animator;
        [SerializeField] private string animName;

        private void Start()
        {
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            
            animator.Play(animName);
        }

        private void Update()
        {
            agent.speed = destinyAgent.speed;
            agent.SetDestination(destination.position);
        }
    }
}
