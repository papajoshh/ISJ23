using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using GameEvents;
using NavMeshPlus.Components;

public class MazeManager : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private NavMeshSurface navMeshSurface;
    [SerializeField] private LightManager lightManager;
    [SerializeField] private GameObject initialPlayerPosition;
    [SerializeField] private GameObject dayTime;
    [SerializeField] private GameObject nightTime;
    [SerializeField] private GameObject houseTeleport;

    [Header("[Configuration]")]
    [SerializeField] private int plantsNeeded;

    [Header("[Events]")]
    [SerializeField] private GameEvent spawnEnemy;

    [Header("[Values]")]
    [SerializeField] private int plantsObtained;


    private void Start()
    {
        Player_DropBread.instance.RestoreBreadAmount();
        Player_DropBread.instance.gameObject.transform.position = initialPlayerPosition.transform.position;
        navMeshSurface.BuildNavMesh();
    }

    public void OnPlantObtained()
    {
        plantsObtained++;
        lightManager.Darken();

        if(plantsObtained == plantsNeeded -1)
        {
            dayTime.SetActive(false);
            nightTime.SetActive(true);
            spawnEnemy.Raise();
        }

        if (plantsObtained >= plantsNeeded)
            houseTeleport.SetActive(true);
    }


}
