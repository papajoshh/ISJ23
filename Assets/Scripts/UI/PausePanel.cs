using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PausePanel : MonoBehaviour
    {
        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
        }

        public void OnClick_Resume()
        {
            gameObject.SetActive(false);
        }

        public void OnClick_Settings()
        {
            Debug.Log("(TODO) Programar opciones ingame");
        }

        public void OnClick_MainMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
