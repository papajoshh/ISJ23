using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Core
{
    public class FinishMapItem : MonoBehaviour
    {
        [Header("[References]")]
        [SerializeField] private MazeManager mazeManager;

        [Header("[Configuration]")]
        [SerializeField] private string sceneName;
        [SerializeField] private List<DialogScriptable> exitDialog;
        

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
                OnContact();
        }

        private void OnContact()
        {
            if(mazeManager.plantsObtained >= 4)
            {
                StaticData.gamePhase++;
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                UI_DialogPanel.instance.onEndDialog += OnEndExitDialog;
                UI_DialogPanel.instance.ShowDialog(exitDialog);
            }
        }


        private void OnEndExitDialog()
        {
            UI_DialogPanel.instance.onEndDialog -= OnEndExitDialog;
            GameStateController.Instance.ChangeGameStateTo(GameStateController.GameState.Gameplay);
        }

    }
}
