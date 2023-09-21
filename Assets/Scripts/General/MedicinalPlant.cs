using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicinalPlant : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private MazeManager mazeManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            TakePlant();
    }

    private void TakePlant()
    {
        mazeManager.OnPlantObtained();
        gameObject.SetActive(false);
    }
}
