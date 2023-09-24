using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStartEvent : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator startAnimator;

    [Header("[Sounds]")]
    [SerializeField] private AudioClip thunderSFX;


    public void Play_StartAnimation()
    {
        startAnimator.Play("START");
    }

    public void Play_ThunderSFX()
    {
        audioSource.PlayOneShot(thunderSFX);
    }

    public void LoadGameplay()
    {
        SceneManager.LoadScene("Gameplay Casa");
    }
}
