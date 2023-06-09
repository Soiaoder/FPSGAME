using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AI.Steering
{
    internal class SteeringForArrival : Steering
    {
        public float slowdownDistance = 5;
        public float arrivalDistance = 2;
        public override Vector3 GetForce()
        {
            float distance = Vector3.Distance(target.transform.position, transform.position)-arrivalDistance;
            //减速区外 保持在最高速
            float realSpeed = speed;
            //到达区
            if (distance <= 0)
                return Vector3.zero;
            //减速区内
            if (distance < slowdownDistance)
            {
                realSpeed = distance / (slowdownDistance - arrivalDistance) * speed;
                realSpeed=realSpeed<1? 1 : realSpeed;
            }
            expectForce = (target.position - transform.position).normalized * realSpeed;
            return (expectForce - vehicle.currentForce) * weight;
        }
    }
}
