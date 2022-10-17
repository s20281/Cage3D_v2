using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour
{
    public GameObject icon;
    public GameObject image;
    public EquipmentSlotType slotType;

    public void OnPressed()
    {
        var invUI = GameManager.UIManager.inventoryUI;
        var activeInv = GameManager.TeamManager.heroes[GameManager.TeamManager.GetCurrentHeroId()].GetComponent<Inventory>();
        var eqSlot = GetEquipmentSlot();

        if (!invUI.holdingItem)
        {
            if (!eqSlot.isEmpty)
            {
                invUI.heldItemIcon.GetComponent<HeldItem>().SetHeldItem(activeInv.RemoveEqItem(eqSlot), image);

                icon.SetActive(true);
                image.SetActive(false);
                GameManager.UIManager.inventoryUI.RefreshInventory();
            }
        }
        else
        {
            if (eqSlot.isEmpty && CanEquip())
            {
                var held = invUI.heldItemIcon.GetComponent<HeldItem>().GetHeldItem();
                activeInv.SetEqItem(held, eqSlot);
                icon.SetActive(false);
                image.GetComponent<Image>().sprite = held.itemData.icon;
                image.SetActive(true);
            }
        }
    }

    private bool CanEquip()
    {
        var itemCategory = GameManager.UIManager.inventoryUI.heldItemIcon.GetComponent<HeldItem>().item.itemData.itemCategory;

        switch (slotType)
        {
            case EquipmentSlotType.PrimaryWeapon:
            case EquipmentSlotType.SecondaryWeapon:
                return (itemCategory == ItemCategory.Weapon);
            case EquipmentSlotType.Armor1:   
            case EquipmentSlotType.Armor2:
            case EquipmentSlotType.Armor3:
            case EquipmentSlotType.Armor4:
                return (itemCategory == ItemCategory.Armor);
            default:
                return false;
        }
    }

    public EquipmentSlot GetEquipmentSlot()
    {
        var activeInv = GameManager.TeamManager.heroes[GameManager.TeamManager.GetCurrentHeroId()].GetComponent<Inventory>();

        switch (slotType)
        {
            case EquipmentSlotType.PrimaryWeapon:
                return activeInv.primaryWeapon;
            case EquipmentSlotType.SecondaryWeapon:
                return activeInv.secondaryWeapon;
            case EquipmentSlotType.Armor1:
                return activeInv.armor1;
            case EquipmentSlotType.Armor2:
                return activeInv.armor2;
            case EquipmentSlotType.Armor3:
                return activeInv.armor3;
            case EquipmentSlotType.Armor4:
                return activeInv.armor4;
            default:
                Debug.LogError("nie ma takiego typu");
                return null;
        }
    }
}

public enum EquipmentSlotType
{
    PrimaryWeapon,
    SecondaryWeapon,
    Armor1,
    Armor2,
    Armor3,
    Armor4
}
