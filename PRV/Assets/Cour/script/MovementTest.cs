using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementTest : MonoBehaviour
{
    public GameObject target;

    private NavMeshAgent agent;

    private void Awake()
    {
        if (TryGetComponent<NavMeshAgent>(out agent))
            return;
        else
            gameObject.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(SearchTarget());
    }

    private IEnumerator SearchTarget()
    {
        while (target && agent && true)
        {
            NavMeshPath p = new NavMeshPath();
            agent.CalculatePath(target.transform.position, p);
            agent.ResetPath();
            agent.SetPath(p);
            Debug.Log(p.status);
            yield return new WaitForSeconds(0f);
        }
    }


}
