using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace AI.Steering
{
    public class LocomotionController : Vehicle
    {
        /// <summary>
        /// 转向 :当前操控方向
        /// </summary>
        public void Rotation()
        {
            if (currentForce != Vector3.zero)// 1当前操控力(位置变化)
            {
                var dir = Quaternion.LookRotation(currentForce);//算出角度
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    dir, rotationSpeed * Time.deltaTime);//缓冲旋转朝向目标
            }
        }
        /// <summary>
        /// 移动（坐标赋值）
        /// </summary>
        public void Movement()
        {
            //1计算出当前的操控方向和速度
            //当前操作力=（当前操作力+合力）*0.02f
            currentForce += finalForce * Time.deltaTime;
            //限制上限最大力
            currentForce = Vector3.ClampMagnitude(currentForce, maxSpeed);
            //2移动
            //位置=（位置+操作力）*0.02f
            transform.position += currentForce * Time.deltaTime;
        }
        /// <summary>
        /// 播放移动动画（或跑或走）
        /// </summary>
        public void PlayAnimation() { }
        ///以上方法，需要反复调用
        private void Update()//每帧刷新
        {
            Rotation();
            Movement();
            PlayAnimation();
        }
    }
}
