using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_EndingCredits : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private Animator endingAnimator;
    [SerializeField] private GameObject endingPanel1;
    [SerializeField] private GameObject endingPanel2;
    [SerializeField] private GameObject endingCreditsPanel;


    public void Play_Ending()
    {
        endingPanel1.SetActive(true);
        endingAnimator.Play("ENDING 1");
    }

    public void Play_Ending2()
    {
        endingPanel2.SetActive(true);
        endingAnimator.Play("ENDING 2");
    }

    public void Load_MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
