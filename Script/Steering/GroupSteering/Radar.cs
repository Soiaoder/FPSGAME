using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
namespace AI.Steering
{
    [System.Serializable]
    public class Radar 
    {
        
        public string neighborTag = "neighbor";
        public float scanRadius = 10;
        public GameObject[] ScanNeighbors(Vector3 selfPosition)
        {
            var array = GameObject.FindGameObjectsWithTag(neighborTag);
            Array.FindAll(array, go => Vector3.Distance(go.transform.position, selfPosition) < scanRadius);
return array;
        }
    }
}

