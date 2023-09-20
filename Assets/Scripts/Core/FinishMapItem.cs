using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class FinishMapItem : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                StaticData.gamePhase++;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
