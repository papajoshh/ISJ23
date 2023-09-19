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
    [SerializeField] private float characterPerSecond;
    
    [Header("[Audio]")]
    [SerializeField] private AudioClip characterSFX;

    [Header("[Values]")]
    [SerializeField] private List<DialogScriptable> dialogList;
    [SerializeField] private int currentDialogIndex;
    [SerializeField] private bool typingText;


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


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && typingText == false)
        {
            ShowNextDialog();
        }
    }


    public void ShowDialog(List<DialogScriptable> newDialogList)
    {
        CleanDialog();
        dialogList = newDialogList;
        dialogPanel.SetActive(true);

        ShowNextDialog();
    }

    private void ShowNextDialog()
    {
        if(currentDialogIndex <= dialogList.Count)
        {
            TypeDialog();
            currentDialogIndex++;
        }
        else
        {
            CloseDialog();
        }
    }


    private void TypeDialog()
    {
        StartCoroutine(Coroutine_TypeDialog());

        IEnumerator Coroutine_TypeDialog()
        {
            yield return new WaitForSeconds(0.5f);

            foreach (var c in dialogList[currentDialogIndex].dialogText)
            {
                dialogText.text += c;
                yield return new WaitForSeconds(1 / characterPerSecond);
            }

            typingText = false;

            if(currentDialogIndex < dialogList.Count)
                continueArrow.SetActive(true);
            else
                continueArrow.SetActive(false);
        }
    }

    private void CloseDialog()
    {
        dialogPanel.SetActive(false);
    }

    private void CleanDialog()
    {
        currentDialogIndex = 0;
        dialogText.text = "";
        typingText = false;
    }
}
