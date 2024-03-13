using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerLocomotion : MonoBehaviour
{
    public NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MovePlayer(RaycastHit hit)
    {
        Debug.Log(agent.hasPath);
        if (agent.hasPath) return;
        agent.SetDestination(hit.point);
    }
}
