using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots;

    public EquipmentSlot meleeWeapon;
    public EquipmentSlot rangeWeapon;
    public EquipmentSlot helmet;
    public EquipmentSlot armor;
    public EquipmentSlot consumable;
    public EquipmentSlot special;
    public HeldItem heldItem;

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

        meleeWeapon = new EquipmentSlot();
        rangeWeapon = new EquipmentSlot();
        helmet = new EquipmentSlot();
        armor = new EquipmentSlot();
        consumable = new EquipmentSlot();
        special = new EquipmentSlot();
    }

    public bool AddItem(Item item, int index = -1)
    {
        if (index == -1)
            index = FindFreeSlot();

        if (index == -1)
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

    public ItemData RemoveEqItem(EquipmentSlot eqSlot)
    {

        if (eqSlot.isEmpty)
        {
            Debug.LogError("no item");
            return null;
        }

        eqSlot.isEmpty = true;

        return eqSlot.itemData;
    }

    public void SetEqItem(Item item, EquipmentSlot eqSlot)
    {
        eqSlot.itemData = item.itemData;
        eqSlot.isEmpty = false;
    }

    public ItemData RemoveItem(int ID)
    {
        if (slots[ID].isEmpty)
        {
            Debug.LogError("no item");
            return null;
        }

        if (slots[ID].count > 1)
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

    public int FindFreeSlot()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].isEmpty)
                return i;
        }
        return -1;
    }

    public bool RemoveItemFromInventory(Item item)
    {
        var countId = -1;

        foreach (InventorySlot slot in slots)
        {
            countId++;

            if (slot != null)
            {

                if (slot.itemData == item.itemData)
                {
                    if (RemoveItem(countId) != null)
                    {
                        return true;
                    }
                }

            }
        }

        return false;


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

public class EquipmentSlot
{
    public ItemData itemData;
    public EquipmentSlotType type;
    public bool isEmpty = true;
}
