using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour
{
    public int ID;
    public GameObject icon;
    public GameObject count;


    public void OnPressed()
    {
        var invUI = GameManager.UIManager.inventoryUI;
        var activeInv = GameManager.TeamManager.heroes[GameManager.TeamManager.GetCurrentHeroId()].GetComponent<Inventory>();

        if (!invUI.holdingItem)
        {
            if (!activeInv.slots[ID].isEmpty)
            {
                invUI.heldItemIcon.GetComponent<HeldItem>().SetHeldItem(activeInv.RemoveItem(ID), icon);
            }
        }
        else
        {
            if (activeInv.slots[ID].isEmpty)
            {
                var held = invUI.heldItemIcon.GetComponent<HeldItem>().GetHeldItem();
                activeInv.AddItem(held, ID);
            }
        }


    }

    public void OnRightButtonClick()
    {
        Debug.Log(gameObject.GetComponent<InventorySlotUI>().ID);

        if (Input.GetMouseButtonDown(1))
        {
            GameManager.UIManager.inventoryOptionsUI.SetPosition(Input.mousePosition);
            GameManager.UIManager.inventoryOptionsUI.SetInventorySlotInfo(icon);
            GameManager.UIManager.inventoryOptionsUI.ShowOptions(ID, gameObject, null);
        }
    }

}
