using AI.Perception;
using System.Collections;
using UnityEngine;

namespace AI.Perception
{
    public class SightSensor : AbstractSensor
    {
        public float sightDistance;
        public float sightAngle;
        public bool enableAngle;
        //
        public bool enableOcclusion;
        public Transform sendPos;
        public override void Init()
        {
            if (sendPos == null)
            {
                sendPos = transform;
            }
        }

        protected override bool TestTrigger(AbstractTrigger trigger)
        {
            if (trigger.triggerType != TriggerType.Sight) return false;
            var tempTrigger = trigger as SightTrigger;

            RaycastHit hit;
            var dir = tempTrigger.recvPos.position - sendPos.position;
            var result=dir.magnitude < sightDistance;
            //Angle
            if (enableAngle)
            {
                bool b1=Vector3.Angle(transform.forward, dir) < sightAngle / 2;
                result=result&& b1;
            }
            //Occlusion
            if(enableOcclusion)
            {
                bool b1 = Physics.Raycast(sendPos.position, dir, out hit,
                    sightDistance) && hit.collider.gameObject == trigger.gameObject;
                result=result&& b1;
            }
            return result;
        }
    }
}