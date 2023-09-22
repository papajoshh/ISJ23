using System;
using UnityEngine;

namespace UI
{
    public class PausePanelActive : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pausePanel.SetActive(true);
            }
        }
    }
}
