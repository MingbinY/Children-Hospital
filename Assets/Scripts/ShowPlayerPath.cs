using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShowPlayerPath : MonoBehaviour
{
    NavMeshAgent agent;
    public LineRenderer lineRenderer;
    public LayerMask ignoreLayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (!GetComponent<LineRenderer>())
            gameObject.AddComponent<LineRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdatePath();
    }

    void UpdatePath()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (agent.hasPath)
        {
            NavMeshPath path = agent.path;
            lineRenderer.enabled = true;
            lineRenderer.positionCount = path.corners.Length;
            lineRenderer.SetPositions(path.corners);
        }
        else if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                NavMeshPath path = new NavMeshPath();
                if (agent.CalculatePath(hit.point, path))
                {
                    lineRenderer.enabled = true;
                    lineRenderer.positionCount = path.corners.Length;
                    lineRenderer.SetPositions(path.corners);
                }
            }
            else
            {
                lineRenderer.positionCount = 0;
                lineRenderer.enabled=false;
            }
        }
        else
        {
            lineRenderer.positionCount = 0;
            lineRenderer.enabled = false;
        }
    }
}
