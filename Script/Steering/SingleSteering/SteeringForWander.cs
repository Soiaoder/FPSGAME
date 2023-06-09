using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

///<summary>
///
///</summary>\
namespace AI.Steering{
    public class SteeringForWander : Steering
    {
        #region Field
        //1 distance between center and vehicle
        public float wanderDistance = 10;
        //the radius of the wandering circle
        public float wanderRadius = 15;
        //3 the maximum offset
        public float maxOffset = 200;
        public float changeTargegtInterval = 3;
        private Vector3 circleTarget;//relevant center

        //4 target point
        private Vector3 targetPos;
        #endregion
        protected void Start()
        {
            base.Start();
            circleTarget = new Vector3(wanderRadius, 0, 0);
            InvokeRepeating("ChangeTarget", 0, changeTargegtInterval);
        }
        public void ChangeTarget()
        {
            //Set initial targetPos
            Vector3 offset=new Vector3(Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset));
            Vector3 offsetPos = circleTarget + offset;

            //accordingly randomly generate the offset pos
            //project it to the circle relevant to the center of it
            circleTarget = offsetPos.normalized * wanderRadius;
            //transferred to world coord
            targetPos=transform.position+transform.forward*wanderDistance+circleTarget;
        }
        public override Vector3 GetForce()
        {
            expectForce = (targetPos - transform.position).normalized * speed;
            return (expectForce - vehicle.currentForce) * weight;
        }
        private void OnDrawGizmos()
        {
            //wander circle forehead
            var sphereCenter=transform.position+transform.forward* wanderRadius;
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(sphereCenter, 1);
        }
    }
}

