using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour
{
    PlayerLocomotion playerLocomotion;
    PlayerInteract playerInteract;

    private void Start()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerInteract = GetComponent<PlayerInteract>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                    playerLocomotion.MovePlayer(hit);
                else if (hit.collider.gameObject.GetComponent<Interactable>())
                {
                    playerLocomotion.MovePlayer(hit);
                    playerInteract.Interact(hit.collider.gameObject.GetComponent<Interactable>());
                }
            }
        }
    }
}
