using AI.Perception;
using System.Collections;
using UnityEngine;

namespace AI.Perception
{
    public class SightTrigger : AbstractTrigger
    {
        public Transform recvPos;
        public override void Init()
        {
            if (recvPos == null)
                recvPos = transform;
            triggerType = TriggerType.Sight;
        }
    }
}