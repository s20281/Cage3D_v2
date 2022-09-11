using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float interactionRange = 4f;
    private bool canInteract;

    public List<Outline> outlines = new List<Outline>();
    void Start()
    {
        canInteract = false;
    }

    public abstract void Interact();

    void OnMouseOver()
    {
        if (GameManager.instance.playerManager.DistanceFromPlayer(transform.position) < interactionRange)
        {
            canInteract = true;
            foreach (Outline outline in outlines)
            {
                outline.enabled = true;
            }
        }
        else
        {
            canInteract = false;
            foreach (Outline outline in outlines)
            {
                outline.enabled = false;
            }
        }

        if (canInteract && Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }
    void OnMouseExit()
    {
        foreach (Outline outline in outlines)
        {
            outline.enabled = false;
        }
    }
}
