using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_EndingCredits : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private AudioSource audiosourceMusica;
    [SerializeField] private AudioSource audiosourceSFX;
    [SerializeField] private Animator endingAnimator;
    [SerializeField] private GameObject endingPanel;

    [Header("[Sounds]")]
    [SerializeField] private AudioClip endingMusic;
    [SerializeField] private AudioClip screamerSFX;


    public void Play_Ending()
    {
        endingPanel.SetActive(true);
        endingAnimator.Play("ENDING");
    }

    public void Play_EndingMusic()
    {
        audiosourceMusica.PlayOneShot(endingMusic);
    }

    public void Play_ScreamerSFX()
    {
        audiosourceSFX.PlayOneShot(screamerSFX);
    }

    public void Load_MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
