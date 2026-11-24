using System.Collections;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class BehaviourTreeTest : MonoBehaviour
    {
        private NodeTest _root = null;
        private BlackBoardTEst bB;

        public float TickInterval = 1f;

        protected void Start()
        {
            bB = new();
            GameObject self = gameObject;
            bB.SetValue<GameObject>("gameObject", ref self);
            _root = SetupTree(ref bB);
            StartCoroutine(UpdateBT());
        }


        protected abstract NodeTest SetupTree(ref BlackBoardTEst blackBoard);

        IEnumerator UpdateBT()
        {
            while(_root != null)
            {
                _root.Evaluate();
                yield return new WaitForSeconds(TickInterval);
            }
        }
    }  
}
