using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeIntro : MonoBehaviour
{
    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> level1_IntroDialog;
    [SerializeField] private List<DialogScriptable> level2_IntroDialog;
    [SerializeField] private List<DialogScriptable> level3_IntroDialog;
    [SerializeField] private List<DialogScriptable> level4_IntroDialog;


    private void Start()
    {

        switch (StaticData.gamePhase)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

    private void Play_Level1_Intro()
    {
        StartCoroutine(Coroutine_LevelIntro());

        IEnumerator Coroutine_LevelIntro()
        {
            yield return null;
        }
    }

    private void Play_Level2_Intro()
    {
        StartCoroutine(Coroutine_LevelIntro());

        IEnumerator Coroutine_LevelIntro()
        {
            yield return null;
        }
    }

    private void Play_Level3_Intro()
    {
        StartCoroutine(Coroutine_LevelIntro());

        IEnumerator Coroutine_LevelIntro()
        {
            yield return null;
        }
    }

    private void Play_Level4_Intro()
    {
        StartCoroutine(Coroutine_LevelIntro());

        IEnumerator Coroutine_LevelIntro()
        {
            yield return null;
        }
    }
}
