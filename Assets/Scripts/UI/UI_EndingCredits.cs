using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_EndingCredits : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private Animator creditsAnimator;
    [SerializeField] private GameObject creditsPanel;


    public void Play_Credits()
    {
        creditsPanel.SetActive(true);
        creditsAnimator.Play("SHOW CREDITS");
    }

    public void Load_MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
