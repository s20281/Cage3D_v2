using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public List<GameObject> inventorySlotsUI = new List<GameObject>();
    public List<GameObject> equipmentSlotsUI = new List<GameObject>();
    public int ActiveInventory;

    public GameObject heldItemIcon;
    public bool holdingItem = true;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<inventorySlotsUI.Count; i++)
        {
            inventorySlotsUI[i].GetComponent<InventorySlotUI>().ID = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ToggleInventory();

        if (Input.GetKeyDown(KeyCode.Escape) && inventoryPanel.activeSelf)
            ToggleInventory();

        if(holdingItem)
        {
            FollowMouse();
        }
    }

    private void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);

        if (inventoryPanel.activeSelf)
        {
            RefreshInventory();
            GameManager.PlayerManager.playerMovement.SwitchFreeze(true);
        }
        else
        {
            GameManager.PlayerManager.playerMovement.SwitchFreeze(false);
        }
    }

    public void RefreshInventory()
    {
        var inv = GameManager.TeamManager.heroes[ActiveInventory].GetComponent<Inventory>();

        for(int i = 0; i < inv.maxItemsCount; i++)
        {
            var slot = inventorySlotsUI[i].GetComponent<InventorySlotUI>();
            if (!inv.slots[i].isEmpty)
            {
                slot.icon.GetComponent<Image>().sprite = inv.slots[i].itemData.icon;
                slot.icon.SetActive(true);
            }
            else
            {
                slot.icon.SetActive(false);
            }
        }

        //for (int i = 0; i < equipmentSlotsUI.Count; i++)
        //{
        //    var slot = equipmentSlotsUI[i].GetComponent<EquipmentSlot>();
        //    if (!inv.slots[i].isEmpty)
        //    {
        //        slot.icon.GetComponent<Image>().sprite = inv.slots[i].itemData.icon;
        //        slot.icon.SetActive(true);
        //    }
        //    else
        //    {
        //        slot.icon.SetActive(false);
        //    }
        //}

    }

    public GameObject GetEquipmentSlot(EquipmentSlot eqSlot)
    {
        var index = -1;
        switch(eqSlot.type)
        {
            case EquipmentSlotType.Armor1:
                index = 0;
                break;
            case EquipmentSlotType.Armor2:
                index = 1;
                break;
            case EquipmentSlotType.PrimaryWeapon:
                index = 2;
                break;
            case EquipmentSlotType.Armor3:
                index = 3;
                break;
            case EquipmentSlotType.Armor4:
                index = 4;
                break;
            case EquipmentSlotType.SecondaryWeapon:
                index = 5;
                break;

        }
        return equipmentSlotsUI[index];
    }

    public void FollowMouse()
    {
        heldItemIcon.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        //Cursor.visible = false;
    }
}
