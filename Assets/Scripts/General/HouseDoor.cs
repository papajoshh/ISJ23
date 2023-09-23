using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoor : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private AudioSource audiosource;

    [Header("[Configuration]")]
    [SerializeField] private GameObject exteriorPosition;
    [SerializeField] private AudioClip doorSFX;
    [SerializeField] private List<DialogScriptable> dialogList;

    [Header("[Values]")]
    public bool talkedToDad;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && talkedToDad == false)
        {
            UI_DialogPanel.instance.onEndDialog += OnEndDialog;

            Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);
            UI_DialogPanel.instance.ShowDialog(dialogList);
        }
        else
        {
            StartCoroutine(Coroutine_TeleportToExterior());
        }
    }

    private void OnEndDialog()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndDialog;
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
        Player_Interactor.instance.EnableInteracting();
    }

    IEnumerator Coroutine_TeleportToExterior()
    {
        UI_FadeCanvas.instance.Play_FadeIn();
        audiosource.PlayOneShot(doorSFX);
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);
        yield return new WaitForSeconds(1.5f);


        SceneManager.LoadScene("Gameplay");
    }
}
