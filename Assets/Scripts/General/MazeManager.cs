using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using GameEvents;

public class MazeManager : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private GameObject playerLight;
    [SerializeField] private GameObject globalLight;
    [SerializeField] private GameObject dayTime;
    [SerializeField] private GameObject nightTime;

    [Header("[Configuration]")]
    [SerializeField] private int plantsNeeded;

    [Header("[Events]")]
    [SerializeField] private GameEvent spawnEnemy;

    [Header("[Values]")]
    [SerializeField] private int plantsObtained;


    private void Start()
    {
        Player_DropBread.instance.RestoreBreadAmount();
    }

    public void OnPlantObtained()
    {
        plantsObtained++;
        GetDarker();
    }


    public void GetDarker()
    {
        switch (plantsObtained)
        {
            case 1:
                Debug.Log("Se hace un poco más de noche");
                break;
            case 2:
                Debug.Log("Se hace un poco más de noche");
                break;
            case 3:
                dayTime.SetActive(false);
                nightTime.SetActive(true);
                spawnEnemy.Raise();

                playerLight.SetActive(true);
                //globalLight.SetActive(true);
                //Esto esta hecho a lo bruto, hay que hacerlo poco a poco
                //eventoNoche.Raise();
                break;
        }

    }

    //public void OnEndMaze()
    //{
    //    UI_DialogPanel.instance.onEndDialog += OnEndMazeDialog;
    //    GameStateController.Instance.ChangeGameStateTo(GameStateController.GameState.Pause);

    //    StartCoroutine(Coroutine_OnEndMaze());

    //    IEnumerator Coroutine_OnEndMaze()
    //    {
    //        UI_FadeCanvas.instance.Play_FadeIn();
    //        yield return new WaitForSeconds(3);

    //        UI_DialogPanel.instance.ShowDialog(endMazeDialog);
    //    }
    //}

    //private void OnEndMazeDialog()
    //{
    //    UI_DialogPanel.instance.onEndDialog -= OnEndMazeDialog;
    //    StartCoroutine(Coroutine_OnEndMazeDialog());

    //    IEnumerator Coroutine_OnEndMazeDialog()
    //    {
    //        SetNight();
    //        UI_FadeCanvas.instance.Play_FadeOut();
    //        yield return new WaitForSeconds(2);

    //        GameStateController.Instance.ChangeGameStateTo(GameStateController.GameState.Gameplay);
    //    }
    //}
}
