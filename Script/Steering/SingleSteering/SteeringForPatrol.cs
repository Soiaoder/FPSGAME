using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
namespace AI.Steering{
    public class SteeringForPatrol : Steering
    {
        public enum PatrolMode { Once,Loop,PingPong};
        public Transform[] WayPoints;
        private int currentWPIndex = 0;
        public PatrolMode patrolMode;
        public float patrolArrivalDistance;
        public override Vector3 GetForce()
        {
            if (Vector3.Distance(WayPoints[currentWPIndex].position, transform.position) < patrolArrivalDistance)
            {
                if (currentWPIndex == WayPoints.Length - 1)
                {
                    switch (patrolMode)
                    {
                        case PatrolMode.Once:
                            return Vector3.zero;
                        case PatrolMode.PingPong:
                            Array.Reverse(WayPoints);
                            break;

                    }
                }
                currentWPIndex=(currentWPIndex+1)%(WayPoints.Length);

            }
            expectForce = (WayPoints[currentWPIndex].position - transform.position).normalized * speed;
            return (expectForce - vehicle.currentForce) * weight;

        }
    }
}
