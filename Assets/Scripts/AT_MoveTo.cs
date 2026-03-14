using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_MoveTo : ActionTask {



		public BBParameter<Transform> locatoin;

		public BBParameter<GameObject> target;

        public float speed;

        public float range;
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

            Vector3 position = agent.transform.position;

            Vector3 targetPosition = target.value.transform.position;

            float Distance = Vector3.Distance(position, targetPosition);

            if (Distance >= range)
            {
                agent.transform.position = Vector3.MoveTowards(position, locatoin.value.position, speed * Time.deltaTime);

                if (position == locatoin.value.position)
                {
                    EndAction(true);
                }
                else
                {
                    
                }
            }
            else
            {
                EndAction(true);
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