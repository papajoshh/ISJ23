using System;
using UnityEngine;

namespace Core
{
    public class TriggerItem : MonoBehaviour
    {

        [SerializeField] private GameObject prefabToInstantiate;
        [SerializeField] private Transform pos;

        [Header("Obj Exit")] 
        [SerializeField] private GameObject exitObj;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                PlayerTakeObject();
                Destroy(this.gameObject);
            }
        }

        private void PlayerTakeObject()
        {
            Instantiate(prefabToInstantiate, pos.position, prefabToInstantiate.transform.rotation);
            //Activamos el objeto que sirve para escapar del laberinto
            exitObj.SetActive(true);
        }
        
    }
}
