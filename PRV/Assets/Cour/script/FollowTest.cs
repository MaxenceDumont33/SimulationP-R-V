using UnityEngine;
using UnityEngine.AI;

namespace BehaviorTree
{
    public class FollowTest : LeafTest
    {
        private float cacheFovDot;
        private float range;
        private string targetTag;
        public FollowTest(ref BlackBoardTEst blackBoard)
            : base(ref blackBoard)
        {
        }

        public override NodeState Evaluate()
        {
            GameObject self = null;
            if (!_blackBoard.TryGetValue<GameObject>("gameObject", ref self))return NodeState.FAILURE;
            NavMeshAgent navAgent = null;
            if(!self.TryGetComponent<NavMeshAgent>(out navAgent)) return NodeState.FAILURE;

            GameObject target = null;
            if(!_blackBoard.TryGetValue<GameObject>("target", ref target)) return NodeState.FAILURE;

            NavMeshPath p = new();
            navAgent.ResetPath();
            navAgent.CalculatePath(target.transform.position, p);
            navAgent.SetPath(p);
            float remainingDistance = Vector3.Distance(self.transform.position,target.transform.position);
            NodeState state = remainingDistance > 1 ? NodeState.Running : NodeState.SUCCESS;
            Debug.Log("Follow.Evaluate " + state);
            return remainingDistance > 1 ? NodeState.Running : NodeState.SUCCESS;
        }

       
    }
}