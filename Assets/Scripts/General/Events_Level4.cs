using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events_Level4 : MonoBehaviour
{
    public static Events_Level4 instance;

    [Header("[References]")]
    //[SerializeField] private EndingCanvas endingCanvas;
    [SerializeField] private MazeManager mazeManager;

    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> levelIntroDialog;
    [SerializeField] private List<DialogScriptable> santaCompañaDialog;

    private void Awake()
    {
        CreateSingleton();
    }
    private void CreateSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        Play_LevelIntro();
    }

    private void Play_LevelIntro()
    {
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);
        StartCoroutine(Coroutine_LevelIntro());

        IEnumerator Coroutine_LevelIntro()
        {
            UI_FadeCanvas.instance.Play_FadeOut();
            yield return new WaitForSeconds(2);

            UI_DialogPanel.instance.onEndDialog += OnEndDialog;
            UI_DialogPanel.instance.ShowDialog(levelIntroDialog);
        }
    }

    public void Play_Ending()
    {
        StartCoroutine(Coroutine_PlayEnding());

        IEnumerator Coroutine_PlayEnding()
        {
            UI_DialogPanel.instance.onEndDialog += Show_EndingCredits;
            UI_ScreamerCanvas.instance.ShowScreamerImage();
            yield return new WaitForSeconds(1);
            
            UI_DialogPanel.instance.ShowDialog(santaCompañaDialog);
        }
    }

    private void Show_EndingCredits()
    {
        UI_DialogPanel.instance.onEndDialog -= Show_EndingCredits;

        StartCoroutine(Coroutine_ShowCredits());

        IEnumerator Coroutine_ShowCredits()
        {
            UI_FadeCanvas.instance.Play_FadeIn();
            yield return new WaitForSeconds(3);

            //endingCanvas.PlayCredits();
        }
    }

    private void OnEndDialog()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndDialog;
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
    }




}
