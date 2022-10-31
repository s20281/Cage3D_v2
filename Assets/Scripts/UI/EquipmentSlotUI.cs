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
    public ItemCategory slotItemType;

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

        return itemCategory == slotItemType;

        switch (slotType)
        {
            case EquipmentSlotType.MeleeWeapon:
                return (itemCategory == ItemCategory.MeleeWeapon);
            case EquipmentSlotType.RangeWeapon:
                return (itemCategory == ItemCategory.RangeWeapon);
            case EquipmentSlotType.Helmet:
                return (itemCategory == ItemCategory.Helmet);
            case EquipmentSlotType.Armor:
                return (itemCategory == ItemCategory.Armor);
            case EquipmentSlotType.Consumables:
                return (itemCategory == ItemCategory.Consumable);
            case EquipmentSlotType.Special:
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
            case EquipmentSlotType.MeleeWeapon:
                return activeInv.primaryWeapon;
            case EquipmentSlotType.RangeWeapon:
                return activeInv.secondaryWeapon;
            case EquipmentSlotType.Helmet:
                return activeInv.armor1;
            case EquipmentSlotType.Armor:
                return activeInv.armor2;
            case EquipmentSlotType.Consumables:
                return activeInv.armor3;
            case EquipmentSlotType.Special:
                return activeInv.armor4;
            default:
                Debug.LogError("nie ma takiego typu");
                return null;
        }
    }
}

public enum EquipmentSlotType
{
    MeleeWeapon,
    RangeWeapon,
    Helmet,
    Armor,
    Consumables,
    Special
}
