using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
namespace AI.Perception
{
    public abstract class AbstractTrigger : MonoBehaviour
    {
        public abstract void Init();
        private void Start()
        {
            Init();
            SensorTriggerSystem sys = SensorTriggerSystem.instance;
            sys.AddTrigger(this); 
        }
        /// <summary>
        /// 销毁方法：把当前触发器从感应触发系统中移除
        /// </summary>
        public void OnDestroy()
        {
            isRemove = true;
        }
        /// <summary>
        /// 禁用为true
        /// </summary>
        public bool isRemove;
        public TriggerType triggerType;
    }
}
