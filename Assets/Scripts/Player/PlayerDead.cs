using System;
using Core;
using UnityEngine;

namespace Player
{
    public class PlayerDead : MonoBehaviour
    {
        [SerializeField] private GameObject[] cruceirosObj;
        [SerializeField] private Transform[] cruceirosTransform;

        private void Start()
        {
            cruceirosObj = GameObject.FindGameObjectsWithTag("Cruceiro");
            cruceirosTransform = new Transform[cruceirosObj.Length];

            for (int i = 0; i < cruceirosObj.Length; i++)
            {
                cruceirosTransform[i] = cruceirosObj[i].transform;
            }
        }

        public void PlayerDeadFunction()
        {
            
            this.gameObject.transform.position = GetNearestCruceiro(cruceirosTransform).GetChild(0).position;
        }

        private Transform GetNearestCruceiro(Transform[] cruceiro)
        {
            Transform nCruceiro = null;
            float distance = Mathf.Infinity;
            Vector2 currentPos = transform.position;

            foreach (Transform t in cruceiro)
            {
                float dist = Vector3.Distance(t.position, currentPos);
                if (dist < distance)
                {
                    nCruceiro = t;
                    distance = dist;
                }
            }

            return nCruceiro;
        }
        
        
    }
}
