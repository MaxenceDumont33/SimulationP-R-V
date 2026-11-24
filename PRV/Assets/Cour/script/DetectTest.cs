using UnityEngine;

namespace BehaviorTree
{
    public class DetectTest : LeafTest
    {
        private float cacheFovDot;
        private float range;
        private string targetTag;
        public DetectTest(ref BlackBoardTEst blackBoard , string TargetTag, float Range = 5, float Fov = 60) 
            : base(ref blackBoard)
        {
            range = Range;
            cacheFovDot = Mathf.Cos(((2f * Mathf.PI)/360) * (Fov / 2f));
            targetTag = TargetTag;
        }

        public override NodeState Evaluate()
        {
            GameObject self = null;
            _blackBoard.TryGetValue<GameObject>("gameObject", ref self);
            if(self == null) return NodeState.FAILURE;

            float minDist = range + 1;
            GameObject bestMatch = null;
            Collider[] hitCollider = Physics.OverlapSphere(self.transform.position, range);
            foreach(Collider collider in hitCollider)
            {
                if(collider.gameObject.tag != targetTag)
                {
                    Debug.Log(collider.gameObject.tag + " != " + targetTag);
                    continue;
                }
                float dist = Vector3.Distance(collider.gameObject.transform.position, self.transform.position);
                Vector3 dir = Vector3.Normalize(collider.gameObject.transform.position - self.transform.position);
                Debug.Log(Vector3.Dot(self.transform.forward, dir) + "<" + cacheFovDot);
                if (Vector3.Dot(self.transform.forward, dir) < cacheFovDot) continue;

                if (dist <= minDist)
                {
                    minDist = dist;
                    bestMatch = collider.gameObject;
                }
            }

            if (bestMatch == null)
            {
                _blackBoard.ClearValue<GameObject>("target");
                Debug.Log("Detect.Evaluate NodeState.FAILURE");
                return NodeState.FAILURE;
            }
            _blackBoard.SetValue<GameObject>("target",ref bestMatch);

            return NodeState.SUCCESS;
        }
    }
}