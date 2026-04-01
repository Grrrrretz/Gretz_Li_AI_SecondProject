using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Rotation : ActionTask {
        public BBParameter<Transform> target;
        public BBParameter<float> Langle = -30f;
        public BBParameter<float> Rangle = 30f;
        public BBParameter<float> rotateSpeed = 60f;

        private float startY;
        private bool turningRight = false;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            startY = target.value.eulerAngles.y;
            turningRight = false;
        }

        protected override void OnUpdate()
        {
            float currentY = target.value.eulerAngles.y;

            float relativeY = Mathf.DeltaAngle(startY, currentY);

            if (!turningRight)
            {
                target.value.Rotate(0, -rotateSpeed.value * Time.deltaTime, 0);

                if (relativeY <= Langle.value)
                {
                    turningRight = true;
                }
            }
            else
            {
                target.value.Rotate(0, rotateSpeed.value * Time.deltaTime, 0);

                if (relativeY >= Rangle.value)
                {
                    EndAction(true);
                }
            }
        }

        protected override void OnStop()
        {
        }

        protected override void OnPause()
        {
        }
    }
}