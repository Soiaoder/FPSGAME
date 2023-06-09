using AI.Steering;
using UnityEngine;

namespace AI.Steering
{
    public class SteeringForFlee:Steering
    {
        public float safeDistance = 10;
        public override Vector3 GetForce()
        {
            if (target == null) return Vector3.zero;
            var dir = transform.position - target.position;
            if (dir.magnitude < safeDistance)
            {
                //当前
                //vehicle.currentForce
                //期望 =(目标位置-？？)
                expectForce = dir.normalized * speed;
                //实际=（期望-当前）*权重
                var realForce = (expectForce - vehicle.currentForce) * weight;
                return realForce;
            }
            else
                return Vector3.zero;
            
        }
    }
}
