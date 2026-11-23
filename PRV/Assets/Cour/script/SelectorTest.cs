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
            return NodeState.FAILURE;
        }
 
    }
}
