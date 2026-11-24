using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace BehaviorTree
{
    public class SequenceTest : CompositeTest
    {
        public SequenceTest(ref BlackBoardTEst blackBoard, List<NodeTest> children)
            : base(ref blackBoard, children) { }

        public override NodeState Evaluate()
        {

            bool anyChildIsRunning = false;
            foreach (NodeTest node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.Running:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }

            state = anyChildIsRunning ? NodeState.Running : NodeState.SUCCESS;
            return state;
        }
    }

}
