using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Rotation : ActionTask {
		public BBParameter<Transform> target;
		public BBParameter<float> Langle;
		public BBParameter<float> Rangle;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			target.value.Rotate(0, Langle.value * Time.deltaTime, 0);
				if (target.value.rotation.y <= Langle.value)
				{
					target.value.rotation = Quaternion.Euler(0, Rangle.value, 0);
					if (target.value.rotation.y >= Rangle.value)
					{
						EndAction(true);
					}
                    
				}


        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}