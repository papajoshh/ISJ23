using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_DialogPanel : MonoBehaviour
{
    public static UI_DialogPanel instance;
    public enum dialogCharacter { KID, FATHER }

    [Header("[References]")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Image characterPortrait;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject continueArrow;

    [Header("[Configuration]")]
    [SerializeField] private Sprite kidPortraitSprite;
    [SerializeField] private Sprite fatherPortraitSprite;
    [SerializeField] private float characterPerSecond;
    
    [Header("[Audio]")]
    [SerializeField] private AudioClip characterSFX; 


    private void Awake()
    {
        CreateSingleton();
    }
    private void CreateSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    public void ShowDialog(dialogCharacter character, string newDialogText)
    {
        dialogPanel.SetActive(true);
        SetCharacter(character);
        TypeDialog(newDialogText);
    }

    private void TypeDialog(string newDialogText)
    {
        StartCoroutine(Coroutine_TypeDialog());

        IEnumerator Coroutine_TypeDialog()
        {
            foreach (var c in newDialogText)
            {
                dialogText.text += c;
                yield return new WaitForSeconds(1 / characterPerSecond);
            }
        }
    }

    private void SetCharacter(dialogCharacter character)
    {
        switch (character)
        {
            case dialogCharacter.KID:
                characterPortrait.sprite = kidPortraitSprite;
                break;
            case dialogCharacter.FATHER:
                characterPortrait.sprite = fatherPortraitSprite;
                break;
        }
    }

}
