using System.Collections;
using UnityEngine;

namespace AI.Steering
{
    public class SteeringForIntercept : Steering
    {
        private Vector2 temp;
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(temp, 1);
        }
        public override Vector3 GetForce()
        {
            //1 distance between target and vehicle itself
            var toTarget = target.position - transform.position;
            var angle = Vector3.Angle(target.forward, toTarget);
            if (angle > 30 && angle < 150)
            {
                //2 time
                var targetSpeed = target.GetComponent<Vehicle>().currentForce.magnitude;
                var time = toTarget.magnitude / (targetSpeed + vehicle.currentForce.magnitude);
                //3 distance covered in induced time
                var runDistance = targetSpeed * time;
                //4 expected steering force
                var interceptPoint = target.position + target.forward * runDistance;
                temp = interceptPoint;
                expectForce = (interceptPoint - transform.position).normalized * speed;
                
            }
            else
            {
                expectForce = toTarget.normalized * speed;
            }
            //5. real = (E-R)*W
            var practicalForce = (expectForce - vehicle.currentForce) * weight;
            return practicalForce;
        }
    }
}