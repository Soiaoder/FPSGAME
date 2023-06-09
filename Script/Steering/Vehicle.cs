using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AI.Steering
{
    /// <summary>
    /// 运动体类
    /// </summary>
    public abstract class Vehicle : MonoBehaviour
    {
        /// <summary>
        /// 1当前操控力
        /// </summary>
        [HideInInspector]
        public Vector3 currentForce;
        /// <summary>
        /// 2合力
        /// </summary>
        [HideInInspector]
        public Vector3 finalForce;
        /// <summary>
        /// 3操控对象数组
        /// </summary>
        [HideInInspector]
        public Steering[] steerings;
        /// <summary>
        /// 4最大速度
        /// </summary>
        public float maxSpeed = 10;
        /// <summary>
        /// 5转向速度
        /// </summary>
        public float rotationSpeed = 5;
        /// <summary>
        /// 6质量
        /// </summary>
        public float mass = 1;
        /// <summary>
        /// 7合力上限
        /// </summary>
        public float maxForce = 100;
        /// <summary>
        /// 8计算间隔
        /// </summary>
        public float computeInternal = 0.2f;
        /// <summary>
        /// 9是否平面
        /// </summary>
        public bool isPlane = false;

        /// <summary>
        /// 计算合力 :把所有对象 实际操控力 求合力；同时考虑质量等问题，返回最终合力
        /// </summary>
        public void ComputeFinalForce()
        {
            //先把合力设置为 
            finalForce = Vector3.zero;//!!!!
            //1把所有对象 实际操控力 求合力
            for (int i = 0; i < steerings.Length; i++)
            {
                if (steerings[i].enabled)
                {
                    finalForce += steerings[i].GetForce();
                }
            }
            if (finalForce == Vector3.zero) currentForce = Vector3.zero;
            //2是否是平面
            if (isPlane) finalForce.y = 0;
            //把向量限制在一个特定的长度，不超过合力上限
            finalForce = Vector3.ClampMagnitude(finalForce, maxForce);
            //3考虑质量 合力=合力/质量
            finalForce /= mass;
        }
        //ComputeFinalForce()要反复调用
        private void OnEnable()
        {
            InvokeRepeating("ComputeFinalForce", 0, computeInternal);
        }
        private void OnDisable()
        {
            CancelInvoke("ComputeFinalForce");
        }
        private void Start()
        {
            steerings = GetComponents<Steering>();
        }
    }
}
