using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class CompositeTest : NodeTest
    {
        protected List<NodeTest> children = new List<NodeTest>();

        public CompositeTest(ref BlackBoardTEst blackBoard , List<NodeTest> Children)
            : base(ref blackBoard)
        {
            children = Children;
        }
    }
}