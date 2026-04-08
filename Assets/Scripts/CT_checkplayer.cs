using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CT_checkplayer : ConditionTask {

        public BBParameter<Light> sLight;
        public BBParameter<Transform> player;
        public BBParameter<LayerMask> obstacleMask;

        protected override string OnInit()
        {
            return null;
        }
        protected override void OnEnable()
        {

        }

        //Called whenever the condition gets disabled.
        protected override void OnDisable()
        {
           
        }
        protected override bool OnCheck()
        {
            Debug.Log(1);
            Transform lightTrans = sLight.value.transform;

            Vector3 targetPosition = player.value.position + Vector3.up;
            Vector3 PlayerDir = targetPosition - lightTrans.position;

            float distanceToPlayer = PlayerDir.magnitude;

            if (distanceToPlayer > sLight.value.range)
            {
                return false;
                Debug.Log(2);
            }

            float angle = Vector3.Angle(lightTrans.forward, PlayerDir);
            if (angle > sLight.value.spotAngle * 0.5f)
            {
                return false;
               Debug.Log(333);
            }

            if (Physics.Raycast(lightTrans.position, PlayerDir.normalized, out RaycastHit hit, distanceToPlayer, obstacleMask.value))
            {
                return false;
                Debug.Log(3);
            }
            return true;
        }
    }
}