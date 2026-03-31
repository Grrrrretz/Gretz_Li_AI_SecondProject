using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class AT_moveTopoint : ActionTask {

        public BBParameter<Transform[]> patrolPoints;
        public BBParameter<int> currentpoint =0;
        public BBParameter<Transform> currentTarget;

        public BBParameter<float> stoppingDistance = 0.2f;

        private NavMeshAgent Agent;
        private Transform targetPoint;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            Agent = agent.GetComponent<NavMeshAgent>();

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {



            targetPoint = patrolPoints.value[currentpoint.value];

            Agent.SetDestination(targetPoint.position);

      



        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            if (Agent.pathPending) return;

            if (Agent.remainingDistance <= stoppingDistance.value)
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