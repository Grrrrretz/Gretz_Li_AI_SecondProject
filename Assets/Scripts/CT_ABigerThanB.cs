using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CT_ABigerThanB : ConditionTask {

		public BBParameter<Transform> A;
		public BBParameter<Transform> B;
		float ASize;
		float BSize;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){

			


            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
            ASize = A.value.localScale.x * A.value.localScale.y * A.value.localScale.z;

            BSize = B.value.localScale.x * B.value.localScale.y * B.value.localScale.z;


        }

        //Called whenever the condition gets disabled.
        protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			if (ASize > BSize)
			{
                return true;
			}
			else
			{
				return false;
            }
			
		}
	}
}