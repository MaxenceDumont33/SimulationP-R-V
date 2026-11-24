using UnityEngine;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class SelectorTest : CompositeTest
    {
        public SelectorTest(ref BlackBoardTEst blackBoard, List<NodeTest> children)
            : base(ref blackBoard , children) { }

        public override NodeState Evaluate()
        {
            foreach(NodeTest node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.Running:
                        state = NodeState.Running;
                        return state;
                    default:
                        continue;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }
 
    }
}
