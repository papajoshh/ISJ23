using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicinalPlant : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private MazeManager mazeManager;

    [Header("[Configuration]")]
    [SerializeField] private List<DialogScriptable> firstPlantDialog;

    [SerializeField] private AudioSource aSource;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            TakePlant();
    }

    private void TakePlant()
    {
        mazeManager.OnPlantObtained();
        gameObject.SetActive(false);
        aSource.Play();
    }

}
