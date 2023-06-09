
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AI.Perception
{
    public class SensorTriggerSystem:MonoSingleton<SensorTriggerSystem>
    {
        private SensorTriggerSystem() { }
        private List<AbstractTrigger> listTrigger=new List<AbstractTrigger>();
        private List<AbstractSensor> listSensor=new List<AbstractSensor>();
        public float checkInterval=0.2f; 
        public void AddSensor(AbstractSensor sensor)
        {
            if (sensor != null)
            {
                listSensor.Add(sensor);
            }
        }
        public void AddTrigger(AbstractTrigger trigger)
        {
            if(trigger != null)
            {
                listTrigger.Add(trigger);
            }
        }
        private void CheckTrigger()
        {
            foreach(var sensor in listSensor)
            {
                if (sensor.enabled)
                {
                    sensor.OnTestTrigger(listTrigger);
                }
            }
        }
        private void OnCheck()
        {
            UpdateSystem();
            CheckTrigger();
        }
        private void OnEnable()
        {
            InvokeRepeating("OnCheck",0,checkInterval);
        }
        private void OnDisable()
        {
            CancelInvoke("OnCheck");
        }
        private void UpdateSystem()
        {
            listSensor.RemoveAll(p => p.isRemove);
            listTrigger.RemoveAll(t => t.isRemove);

        }
    }
}
