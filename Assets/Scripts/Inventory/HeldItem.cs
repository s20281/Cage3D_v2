using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeldItem : MonoBehaviour
{
    public Item item;

    public void SetHeldItem(ItemData itemData, GameObject icon)
    {
        gameObject.SetActive(true);
        //item = new Item();
        item.SetData(itemData);

        GetComponent<Image>().sprite = icon.GetComponent<Image>().sprite;
        GameManager.UIManager.inventoryUI.holdingItem = true;
        Cursor.visible = false;
    }

    public Item GetHeldItem()
    {
        gameObject.SetActive(false);
        GetComponent<Image>().sprite = null;
        GameManager.UIManager.inventoryUI.holdingItem = false;
        Cursor.visible = true;
        return item;
    }
}



