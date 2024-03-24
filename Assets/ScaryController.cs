using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryController : MonoBehaviour
{
    public bool isSeen = false;
    public bool nearDoctor = false;
    public float checkRadius = 1f;

    public void CheckDoctor()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<AILocomotion>() != null)
            {
                nearDoctor = true;
                return;
            }
        }
        nearDoctor = false;
    }

    private void Update()
    {
        CheckDoctor();
        GameManager.Instance.isScary = isSeen || nearDoctor ? true : false;
    }
}
