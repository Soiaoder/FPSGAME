using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace AI.Perception
{
    abstract public class AbstractSensor:MonoBehaviour
    {
        public bool isRemove;
        private void Start()
        {
            Init();
            SensorTriggerSystem sys = SensorTriggerSystem.instance;
            sys.AddSensor(this);
        }
        private void OnDestroy()
        {
            isRemove = true;
        }
        abstract public void Init();
        public  void OnTestTrigger(List<AbstractTrigger> listTriggers)
        {
            //Find all available triggers
            listTriggers=listTriggers.FindAll(t => t.enabled&&t.gameObject!=this.gameObject&&TestTrigger(t));
            if (listTriggers.Count > 0)
            {
                if (OnPerception != null)
                    OnPerception(listTriggers);
            }
            else
            {
                if (OnNonPerception != null)
                    OnNonPerception();
            }
        }
        /// <summary>
        /// test the trigger is noticed by sensor.
        /// </summary>
        /// <param name="trigger"></param>
        protected abstract bool TestTrigger(AbstractTrigger trigger);
        public event Action<List<AbstractTrigger>> OnPerception;
        public event Action OnNonPerception;
    }
}
