using System;
using Core;
using UnityEngine;

namespace SantaCompana
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                GameStateController.Instance.ChangeGameStateTo(GameStateController.GameState.Pause);
                Debug.Log("dead");
            }
        }
    }
}
