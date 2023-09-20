using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoor : MonoBehaviour
{
    [Header("[Configuration]")]
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
            StartCoroutine(FadeInConversationCorroutine());
        }
    }

    private void OnEndDialog()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndDialog;
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
        Player_Interactor.instance.EnableInteracting();
    }

    IEnumerator FadeInConversationCorroutine()
    {
        UI_FadeCanvas.instance.Play_FadeIn();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Gameplay Test Ismael");
    }
}
