using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicinalPlant : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private MazeManager mazeManager;

    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> firstPlantDialog;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            TakePlant();
    }

    private void TakePlant()
    {
        if (StaticData.firstPlantDialog == false)
        {
            StaticData.firstPlantDialog = true;
            UI_DialogPanel.instance.onEndDialog += OnFirstPlant_EndDialog;
            UI_DialogPanel.instance.ShowDialog(firstPlantDialog);
        }
        else
        {
            mazeManager.OnPlantObtained();
            gameObject.SetActive(false);
        }
    }

    private void OnFirstPlant_EndDialog()
    {
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Gameplay);
        mazeManager.OnPlantObtained();
        gameObject.SetActive(false);
    }
}
