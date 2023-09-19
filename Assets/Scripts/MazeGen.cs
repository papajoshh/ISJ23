using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
    [SerializeField] MazeNode nodePrefab;
    [SerializeField] Vector2Int mazeSize;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(generateMaze(mazeSize));
    }
    IEnumerator generateMaze(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();
        for(int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                Vector3 nodePos = new Vector3(x-(size.x/2f),y-(size.y /2f),0);
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newNode);

                yield return null;
            }
        }
        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();
        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
        currentPath[0].SetState(MazeNode.NodeState.Current);

    }

}
