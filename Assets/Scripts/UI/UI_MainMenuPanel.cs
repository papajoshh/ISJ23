using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenuPanel : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;


    public void OnClick_Play()
    {
        SceneManager.LoadScene("Gameplay Casa");
    }

    public void OnClick_Settings()
    {
        settingsPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnClick_Credits()
    {
        creditsPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnClick_Exit()
    {
        Application.Quit();
    }

}
