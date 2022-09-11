using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    public override void Interact()
    {
        // add to inventory
        Debug.Log(gameObject.name + " added to inventory");

        Destroy(gameObject);
    }
}

