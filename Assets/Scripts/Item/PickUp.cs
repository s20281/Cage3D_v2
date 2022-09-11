using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickUpRange = 2f;
    private bool canPickUp;

    public List<Outline> outlines = new List<Outline>();
    void Start()
    {
        canPickUp = false;
    }

    void Update()
    {

    }

    void OnMouseOver()
    {
        if (GameManager.instance.playerManager.DistanceFromPlayer(transform.position) < pickUpRange)
        {
            canPickUp = true;
            foreach (Outline outline in outlines)
            {
                outline.enabled = true;
            }
        }
        else
        {
            canPickUp = false;
            foreach (Outline outline in outlines)
            {
                outline.enabled = false;
            }
        }

        if (canPickUp && Input.GetMouseButtonDown(0))
        {
            // add to inventory
            Destroy(gameObject);
        }
    }
    void OnMouseExit()
    {
        foreach (Outline outline in outlines)
        {
            outline.enabled = false;
        }
    }

    private void OnMouseEnter()
    {
        if(canPickUp)
            Debug.Log(gameObject.name);
    }
}

