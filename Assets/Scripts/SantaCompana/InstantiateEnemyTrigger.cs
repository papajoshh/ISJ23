using UnityEngine;

namespace SantaCompana
{
    public class InstantiateEnemyTrigger : MonoBehaviour
    {
        
        [SerializeField] private GameObject prefabToInstantiate;
        [SerializeField] private Transform pos;

        public void InstantiateEnemy()
        {
            Instantiate(prefabToInstantiate, pos.position, prefabToInstantiate.transform.rotation);
        }
        
    }
}
