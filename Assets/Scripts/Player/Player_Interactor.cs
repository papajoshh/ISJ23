using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Player_Interactor : MonoBehaviour
{
    public static Player_Interactor instance;

    [Header("[References]")]
    [SerializeField] private Player.SimpleMovement playerMovement;

    [Header("[Configuration]")]
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float rayLenght;
    [SerializeField] private bool interacting;


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
        if(interacting == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && GameStateController.Instance.gameState == GameStateController.GameState.Gameplay)
            {
                Interact();
            }
        }
    }

    private void Interact()
    {
        var facingDirection = new Vector3(playerMovement.faceDirection.x, playerMovement.faceDirection.y);

        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, facingDirection, rayLenght, interactableLayer);

        if(hit.collider != null)
        {
            interacting = true;
            hit.transform.gameObject.GetComponent<IInteractable>().Interact();
        }

        Debug.DrawLine(transform.position, transform.position + (facingDirection * rayLenght), Color.red);
    }

    public void EnableInteracting()
    {
        StartCoroutine(Coroutine_EnableInteracting());

        IEnumerator Coroutine_EnableInteracting()
        {
            yield return new WaitForSeconds(0.25f);
            interacting = false;
        }
    }
}
