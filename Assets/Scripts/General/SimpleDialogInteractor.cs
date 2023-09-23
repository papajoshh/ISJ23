using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialogInteractor : MonoBehaviour, IInteractable
{
    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> dialogList;


    public void Interact()
    {
        UI_DialogPanel.instance.onEndDialog += OnEndDialog;

        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);
        UI_DialogPanel.instance.ShowDialog(dialogList);
    }

    private void OnEndDialog()
    {
        UI_DialogPanel.instance.onEndDialog -= OnEndDialog;
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
        Player_Interactor.instance.EnableInteracting();
    }
}
