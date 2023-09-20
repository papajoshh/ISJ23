using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSelector : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private GameObject maze1;
    [SerializeField] private GameObject maze2;
    [SerializeField] private GameObject maze3;
    [SerializeField] private GameObject maze4;


    private void Awake()
    {
        switch (StaticData.gamePhase)
        {
            case 0:
                maze1.SetActive(true);
                break;
            case 1:
                maze2.SetActive(true);
                break;
            case 2:
                maze3.SetActive(true);
                break;
            case 3:
                maze4.SetActive(true);
                break;
        }
    }
}
