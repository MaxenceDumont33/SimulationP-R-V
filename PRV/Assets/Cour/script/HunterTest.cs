using System.Collections.Generic;

namespace BehaviorTree
{
    public class HunterTest : BehaviourTreeTest
    {
        protected override NodeTest SetupTree(ref BlackBoardTEst blackboard)
        {
            return new SequenceTest(ref blackboard, new List<NodeTest>()
            {
                new DetectTest(ref blackboard,"Player", 8, 120),
                new FollowTest(ref blackboard)
            });
        }
    }

}