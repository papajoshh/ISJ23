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
    [SerializeField] private GameObject endingPanel3;
    [SerializeField] private GameObject endingPanel4;
    [SerializeField] private GameObject endingCreditsPanel;

    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> endingDialog1;
    [SerializeField] private List<DialogScriptable> endingDialog2;
    [SerializeField] private List<DialogScriptable> endingDialog3;
    [SerializeField] private List<DialogScriptable> endingDialog4;

    [Header("[Values]")]
    [SerializeField] private int endingPhase;


    public void Play_NextEndingPhase()
    {
        switch (endingPhase)
        {
            case 0:
                Play_Ending1();
                break;
            case 1:
                Play_Ending2();
                break;
            case 2:
                Play_Ending3();
                break;
            case 3:
                Play_Ending4();
                break;
            case 4:
                Play_Credits();
                break;
        }

        endingPhase++;
    }


    public void Play_Ending1()
    {
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);
        UI_DialogPanel.instance.onEndDialog += OnEndDialog;

        endingPanel1.SetActive(true);
        endingAnimator.Play("ENDING 1");
    }

    public void Play_Ending2()
    {
        endingPanel2.SetActive(true);
        endingAnimator.Play("ENDING 2");
    }

    public void Play_Ending3()
    {
        endingPanel3.SetActive(true);
        endingAnimator.Play("ENDING 3");
    }

    public void Play_Ending4()
    {
        endingPanel4.SetActive(true);
        endingAnimator.Play("ENDING 4");
    }

    public void Play_Credits()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndDialog;
        endingCreditsPanel.SetActive(true);
        endingAnimator.Play("SHOW CREDITS");
    }

    public void Show_Ending1_Dialog()
    {
        UI_DialogPanel.instance.ShowDialog(endingDialog1);
    }

    public void Show_Ending2_Dialog()
    {
        UI_DialogPanel.instance.ShowDialog(endingDialog2);
    }

    public void Show_Ending3_Dialog()
    {
        UI_DialogPanel.instance.ShowDialog(endingDialog3);
    }

    public void Show_Ending4_Dialog()
    {
        UI_DialogPanel.instance.ShowDialog(endingDialog4);
    }



    private void OnEndDialog()
    {
        Play_NextEndingPhase();
    }

    public void Load_MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
