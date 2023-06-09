using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace AI.Steering
{
    /// <summary>
    ///1 靠近
    /// </summary>
    public class SteeringForSeek : Steering
    {
        public override Vector3 GetForce()
        {
            if (target == null) return Vector3.zero;
            //当前
            //vehicle.currentForce
            //期望 =(目标位置-？？)
            expectForce = (target.position - transform.position).normalized * speed;
            //实际=（期望-当前）*权重
            var realForce = (expectForce - vehicle.currentForce) * weight;
            return realForce;
        }
    }
}
