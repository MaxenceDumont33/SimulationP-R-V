using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace BehaviorTree
{
    public enum NodeState
    {
        Running,
        SUCCESS,
        FAILURE

    }
    public class NodeTest : MonoBehaviour
    {
        protected NodeState state;

        protected BlackBoardTEst _blackBoard;

        public NodeTest(ref BlackBoardTEst Blackboard)
        {
            _blackBoard = Blackboard;
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;
    }

}