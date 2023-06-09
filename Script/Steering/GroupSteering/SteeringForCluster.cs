using AI.Steering;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
namespace AI.Steering
{
    public class SteeringForCluster : Steering
    {
        public Radar radar = new Radar();
        public float nearDistance;
        public override Vector3 GetForce()
        {
            //1>
            var allNeighbor = radar.ScanNeighbors(transform.position);
            var center = Vector3.zero;
            foreach(var neighbor in allNeighbor)
            {
                center += neighbor.transform.position;

            }
            center/=allNeighbor.Length;
            if (Vector3.Distance(center, transform.position) > nearDistance)
            {
                expectForce = (center - transform.position).normalized * weight;
                return (expectForce - vehicle.currentForce) * weight;
            }
            return Vector3.zero;
        }

    }
}
