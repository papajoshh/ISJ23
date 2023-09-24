using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CreditsPanel : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private GameObject mainMenuPanel;

    public void OnClick_Back()
    {
        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
