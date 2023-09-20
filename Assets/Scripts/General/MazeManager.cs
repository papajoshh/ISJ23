using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class MazeManager : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private GameObject dayTime;
    [SerializeField] private GameObject nightTime;

    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> endMazeDialog;


    public void OnEndMaze()
    {
        UI_DialogPanel.instance.onEndDialog += OnEndMazeDialog;
        GameStateController.Instance.ChangeGameStateTo(GameStateController.GameState.Pause);
        
        StartCoroutine(Coroutine_OnEndMaze());

        IEnumerator Coroutine_OnEndMaze()
        {
            UI_FadeCanvas.instance.Play_FadeIn();
            yield return new WaitForSeconds(3);

            UI_DialogPanel.instance.ShowDialog(endMazeDialog);
        }
    }

    private void OnEndMazeDialog()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndMazeDialog;
        StartCoroutine(Coroutine_OnEndMazeDialog());

        IEnumerator Coroutine_OnEndMazeDialog()
        {
            SetNight();
            UI_FadeCanvas.instance.Play_FadeOut();
            yield return new WaitForSeconds(2);

            GameStateController.Instance.ChangeGameStateTo(GameStateController.GameState.Gameplay);
        }
    }

    public void SetNight()
    {
        dayTime.SetActive(false);
        nightTime.SetActive(true);
    }
}
