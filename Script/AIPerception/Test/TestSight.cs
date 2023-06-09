using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Perception;
using System;
///<summary>
///
///</summary>
public class TestSight : MonoBehaviour
{
    public SightTrigger trigger;
    private void Start()
    {
        SensorTriggerSystem sys=SensorTriggerSystem.instance;
        sys.AddSensor(GetComponent<SightSensor>());
        sys.AddTrigger(trigger);   

        //register the event of sightsensor
        GetComponent<SightSensor>().OnPerception += TestSight_OnPerception;
        GetComponent<SightSensor>().OnNonPerception += TestSight_OnNonPerception;
    }

    private void TestSight_OnNonPerception()
    {
        print("Unseen");
    }

    private void TestSight_OnPerception(List<AbstractTrigger> list)
    {
        list.ForEach(t => print("'ve seen:"+t.name));

    }
}
