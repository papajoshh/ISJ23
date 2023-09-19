using Core;
using Player;
using UnityEngine;
using UnityEngine.AI;

namespace SantaCompana
{
    public class AgentNatComp : MonoBehaviour
    {

        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform player;

        [SerializeField] private float distanceMinPlayer;
        [SerializeField] private float normalSpeed;
        [SerializeField] private float initialDSpeed;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            player = FindObjectOfType<SimpleMovement>().gameObject.transform;
            
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameStateController.Instance.gameState == GameStateController.GameState.Gameplay)
            {
                AgentFollow(player);
                AgentDistance(player);
            }
        }

        private void AgentFollow(Transform target)
        {
            agent.SetDestination(target.position);
        }

        private void AgentDistance(Transform target)
        {
            float distance = Vector3.Distance(this.gameObject.transform.position, target.transform.position);

            agent.speed = distance >= distanceMinPlayer ? initialDSpeed : normalSpeed;
        }
    }
}
