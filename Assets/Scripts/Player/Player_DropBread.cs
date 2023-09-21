using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Player_DropBread : MonoBehaviour
{
    public static Player_DropBread instance;

    [Header("[References]")]
    [SerializeField] private GameObject breadPrefab;

    [Header("[Configuration]")]
    [SerializeField] private int initialAmount;

    [Header("[Values]")]
    [SerializeField] private int currentAmount;


    private void Awake()
    {
        CreateSingleton();
    }
    private void CreateSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && GameStateController.Instance.gameState == GameStateController.GameState.Gameplay)
        {
            DropBread();
        }
    }

    private void DropBread()
    {
        if(currentAmount > 0)
        {
            currentAmount--;
            Instantiate(breadPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }

    public void RestoreBreadAmount()
    {
        currentAmount = initialAmount;
    }

    
}
