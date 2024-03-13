using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInteract : MonoBehaviour
{
    NavMeshAgent agent;

    Interactable currentInteractable;
    bool canInteract = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Interact(Interactable interactable)
    {
        Debug.Log("Player Interact");
        currentInteractable = interactable;
        StartCoroutine(InteractSequence());
    }

    IEnumerator InteractSequence()
    {
        while (!canInteract) yield return null;
        Debug.Log("Player Interact with obj");
        currentInteractable.OnInteract();
        canInteract = false;
        Destroy(currentInteractable.gameObject);
        currentInteractable = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == currentInteractable.gameObject)
        {
            canInteract = true;
        }
    }
}
