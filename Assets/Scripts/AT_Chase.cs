using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions
{

    public class AT_Chase : ActionTask
    {

        public BBParameter<Transform> player;

        private NavMeshAgent navAgent;

        protected override string OnInit()
        {
            navAgent = agent.GetComponent<NavMeshAgent>();

            return null;
        }

        protected override void OnExecute()
        {
            navAgent.speed = 8;
        }

        protected override void OnUpdate()
        {
            navAgent.SetDestination(player.value.position);
        }

        protected override void OnStop()
        {
            navAgent.speed = 4;
        }
    }
}