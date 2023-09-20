using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interactor : MonoBehaviour
{
    [Header("[References]")]
    [SerializeField] private Player.SimpleMovement playerMovement;

    [Header("[Configuration]")]
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float rayLenght;


    private void Update()
    {
        //Comprobar primero si el jugador esta en un estado en el que puede interactuar o no
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }

    private void Interact()
    {
        //Obtenemos la dirección a la que mira el jugador
        var facingDirection = new Vector3(playerMovement.faceDirection.x, playerMovement.faceDirection.y);

        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, facingDirection, rayLenght, interactableLayer);

        if(hit.collider != null)
            hit.transform.gameObject.GetComponent<IInteractable>().Interact();


        Debug.DrawLine(transform.position, transform.position + (facingDirection * rayLenght), Color.red);
    }
}
