using System;
using NavMeshPlus.Components;
using UnityEngine;

namespace Core
{
    public class NavMeshControllerBake : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface navMeshSurface;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                BuildNaveMesh();
            }
        }

        public void BuildNaveMesh()
        {
            navMeshSurface.BuildNavMesh();
        }
    }
}
