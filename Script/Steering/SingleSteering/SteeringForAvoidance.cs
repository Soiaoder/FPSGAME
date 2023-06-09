using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
namespace AI.Steering
{
    public class SteeringForAvoidance : Steering
    {
        //Field
        //Obstacle mark
        public string obstacleTag = "obstacle";
        //Pos of probe
        public Transform probePos;
        //length of probe
        public float probeLength = 15;
        //minimum steering force
        public float minPushForce = 30;
        public override Vector3 GetForce()
        {
            //1.detect if there are coming obstacle
            RaycastHit hit;
            bool ifCo=Physics.Raycast(probePos.position, probePos.forward, out hit, probeLength);
            bool ifOb=(hit.collider.tag==obstacleTag)&&ifCo;
            if (ifOb)
            {
                expectForce=hit.point-hit.transform.position;
                if(expectForce.magnitude<minPushForce)
                {
                    expectForce=expectForce.normalized*minPushForce;
                }
                return expectForce * weight;
            }
            return Vector3.zero;
        }
    }
}
