using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_AvoidSteer : ActionTask {
		public BBParameter<Vector3> targetposition;
		public LayerMask avoidmask;

		public float detecyionDistance;
		public Vector3 totalDirection;

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
			Collider[] detectedColliders = Physics.OverlapSphere(agent.transform.position, detecyionDistance, avoidmask);

			foreach (Collider detectedCollider in detectedColliders)
			{
                Vector3 directionToHazard = detectedCollider.transformHandle.position - agent.transform.position;
				totalDirection -= directionToHazard;

			}

			totalDirection = totalDirection.normalized;

            targetposition.value = agent.transform.position	+ totalDirection;


        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}