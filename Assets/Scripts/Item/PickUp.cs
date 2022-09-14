using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    public override void Interact()
    {
        bool pickedUp = GameManager.instance.teamManager.tryAddItem(GetComponent<Item>());
        if(pickedUp)
        {
            Debug.Log(gameObject.name + " added to inventory");
            Destroy(gameObject);
        }
    }
}

