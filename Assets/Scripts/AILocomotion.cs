using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AiStates
{
    Idle,
    Patrol,
    Chase
}
public class AILocomotion : MonoBehaviour
{
    public GameObject target;

    NavMeshAgent agent;
    AiFOV fov;

    public AiStates defaultState = AiStates.Patrol;
    AiStates currentState;

    public float patrolSpeed = 1f;
    public float patrolWaitTime = 1f;
    float waitTimer = 0f;
    public List<Transform> waypoints;
    int waypointIndex = 0;

    public float gameOverDist = 1f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<PlayerInput>().gameObject;
        fov = GetComponent<AiFOV>();

        waypointIndex = -1;
        waitTimer = 0f;

        currentState = defaultState;
        if (currentState == AiStates.Patrol)
        {
            Patrol(true);
        }
    }
    private void Update()
    {
        switch (currentState)
        {
            case AiStates.Idle:
                IdleUpdate();
                break;
            case AiStates.Patrol:
                PartolUpdate();
                break;
            case AiStates.Chase:
                ChaseUpdate();
                break;
        }
    }
    #region State Machine


    void IdleUpdate()
    {
        if (CanSeeTarget())
        {
            currentState = AiStates.Chase;
            return;
        }
    }

    void PartolUpdate()
    {
        if (CanSeeTarget())
        {
            currentState = AiStates.Chase;
            FindObjectOfType<ScaryController>().isSeen = true;
            return;
        }
        Patrol();
    }

    void ChaseUpdate()
    {
        if (CanCatchPlayer())
        {
            GameManager.Instance.GameOver();
            return;
        }
        agent.SetDestination(target.transform.position);
    }
    #endregion
    #region Actions
    void Patrol(bool firstTime = false)
    {
        if (agent.hasPath) return;

        agent.speed = patrolSpeed;
        waitTimer += Time.deltaTime;
        if (waitTimer >= patrolWaitTime)
        {
            waitTimer = 0;

            waypointIndex++;
            if (waypointIndex >= waypoints.Count)
            {
                waypointIndex = 0;
            }
            agent.SetDestination(waypoints[waypointIndex].position);
        }
    }
    #endregion
    #region conditions
    bool CanSeeTarget()
    {
        return fov.FindVisibleTargets();
    }
    bool CanCatchPlayer()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= gameOverDist) return true;
        return false;
    }
    #endregion
}
