using AI.Steering;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
namespace AI.Steering
{
    public class SteeringForDisperse : Steering
    {
        public Radar radar = new Radar();
        public float nearDistance;
        public override Vector3 GetForce()
        {
            //1>
            var allNeighbor = radar.ScanNeighbors(transform.position);
            var center = Vector3.zero;
            foreach (var neighbor in allNeighbor)
            {
                var dir = transform.position - neighbor.transform.position;
                if(dir.magnitude<nearDistance&&gameObject!=neighbor.gameObject)
                {
                    expectForce += dir.normalized;
                }
            }
            if(expectForce==Vector3.zero) { return Vector3.zero; }
            expectForce = expectForce.normalized*speed;
            return (expectForce - vehicle.currentForce) * weight;
        }

    }
}
