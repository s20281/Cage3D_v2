using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    public override void Interact()
    {
        bool pickedUp = GameManager.TeamManager.tryAddItem(GetComponent<Item>());
        if(pickedUp)
        {
            Debug.Log(gameObject.name + " added to inventory");
            Destroy(gameObject);

            if(GameManager.UIManager.inventoryUI.inventoryPanel.activeSelf)
            {
                GameManager.UIManager.inventoryUI.RefreshInventory();
            }
        }
    }
}

