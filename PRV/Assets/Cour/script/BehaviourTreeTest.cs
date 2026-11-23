using UnityEngine;

namespace BehaviorTree
{
    public abstract class BehaviourTreeTest : MonoBehaviour
    {
        private NodeTest _root = null;
        private BlackBoardTEst bB;

        protected void Start()
        {
            bB = new();
            _root = SetupTree(ref bB);
        }

        private void Update()
        {
            if (_root != null)
                _root.Evaluate();
            
        }

        protected abstract NodeTest SetupTree(ref BlackBoardTEst blacBoard);
    }  
}
