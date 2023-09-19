using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeNode : MonoBehaviour
{
    public enum NodeState
    {
        Available,
        Current,
        Completed
    }
    [SerializeField] GameObject[] walls;
    [SerializeField] SpriteRenderer floor;

    public void SetState(NodeState state)
    {
        switch (state)
        {
            case NodeState.Available:
                floor.color = Color.white;
                break;
            case NodeState.Current:
                floor.color = Color.cyan;
                break;
            case NodeState.Completed:
                floor.color = Color.magenta;
                break;
        }
    }
}
