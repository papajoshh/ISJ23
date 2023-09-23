using UnityEngine;

namespace SantaCompana
{
    public class InstantiateEnemyTrigger : MonoBehaviour
    {
        
        [SerializeField] private GameObject[] prefabToInstantiate;
        [SerializeField] private Transform pos;

        public void InstantiateEnemy()
        {
            for (int i = 0; i < prefabToInstantiate.Length; i++)
            {
                Instantiate(prefabToInstantiate[i], pos.position, prefabToInstantiate[i].transform.rotation);
            }
            
        }
        
    }
}
