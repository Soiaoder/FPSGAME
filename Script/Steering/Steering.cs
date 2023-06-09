using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace AI.Steering
{
    /// <summary>
    /// 操控类：各种自动运动【操控】的 共性
    /// </summary>
    abstract public class Steering : MonoBehaviour
    {
        /// <summary>
        /// 1 期望操控力
        /// </summary>
        [HideInInspector]
        public Vector3 expectForce;
        /// <summary>
        /// 运动体
        /// </summary>
        [HideInInspector]
        public Vehicle vehicle;
        /// <summary>
        /// 目标
        /// </summary>
        public Transform target; //通过监视【属性】窗口赋值    
        /// <summary>
        /// 速度
        /// </summary>
        public float speed = 5;
        /// <summary>
        /// 权重
        /// </summary>
        public int weight = 1;
        /// <summary>
        /// 计算实际操控力
        /// </summary>
        abstract public Vector3 GetForce();
        protected void Start()
        {
            vehicle = GetComponent<Vehicle>();
            if (speed == 0) speed = vehicle.maxSpeed;
        }
    }
}
