using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots;
    public int maxItemsCount = 12;

    private void Start()
    {
        SetupSlots();
    }

    private void SetupSlots()
    {
        slots = new List<InventorySlot>();
        for (int i = 0; i < maxItemsCount; i++)
        {
            var slot = new InventorySlot();
            slot.isEmpty = true;
            slots.Add(slot);
        }
    }

    public bool AddItem(Item item)
    {
        var index = FindFreeSlot();

        if(index == -1)
        {
            Debug.Log("Za ma³o miejsca w inventory");
            return false;
        }

        slots[index].id = item.itemData.id;
        slots[index].itemCategory = item.itemData.itemCategory;
        slots[index].count = 1;
        slots[index].itemData = item.itemData;
        slots[index].isEmpty = false;

        if (GameManager.UIManager.inventoryUI.inventoryPanel.activeSelf)
        {
            GameManager.UIManager.inventoryUI.RefreshInventory();
        }

        return true;
    }

    public ItemData RemoveItem(int ID)
    {
        if (!slots[ID].isEmpty)
        {
            if(slots[ID].count > 1)
            {
                slots[ID].count--;
            }
            else
            {
                slots[ID].id = -1;
                slots[ID].itemCategory = ItemCategory.None;
                slots[ID].count = 0;
                slots[ID].isEmpty = true;
                GameManager.UIManager.inventoryUI.inventorySlotsUI[ID].GetComponent<InventorySlotUI>().icon.SetActive(false);
            }
            if (GameManager.UIManager.inventoryUI.inventoryPanel.activeSelf)
            {
                GameManager.UIManager.inventoryUI.RefreshInventory();
            }

            return slots[ID].itemData;
        }
        else
            return null;
    }

    public int FindFreeSlot()
    {
        for(int i = 0; i < slots.Count; i++)
        {
            if (slots[i].isEmpty)
                return i;
        }
        return -1;
    }
}

public class InventorySlot
{
    public ItemCategory itemCategory;
    public int id;
    public int count;
    public bool isEmpty;
    public ItemData itemData;
}
