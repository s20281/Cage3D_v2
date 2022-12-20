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

    public void OnRightButtonClick()
    {
        var invUI = GameManager.UIManager.inventoryUI;
        var activeInv = GameManager.TeamManager.heroes[GameManager.TeamManager.GetCurrentHeroId()].GetComponent<Inventory>();
        var eqSlot = GetEquipmentSlot();


        if (Input.GetMouseButtonDown(1))
        {
            GameManager.UIManager.inventoryOptionsUI.SetPosition(Input.mousePosition);
            GameManager.UIManager.inventoryOptionsUI.SetEquipmentSlotsInfo(icon, image);
            GameManager.UIManager.inventoryOptionsUI.ShowOptions(-1, gameObject, eqSlot);
        }
    }

    public bool CanEquip()
    {
        var itemCategory = GameManager.UIManager.inventoryUI.heldItemIcon.GetComponent<HeldItem>().item.itemData.itemCategory;

        return itemCategory == slotItemType;

        //switch (slotType)
        //{
        //    case EquipmentSlotType.MeleeWeapon:
        //        return (itemCategory == ItemCategory.MeleeWeapon);
        //    case EquipmentSlotType.RangeWeapon:
        //        return (itemCategory == ItemCategory.RangeWeapon);
        //    case EquipmentSlotType.Helmet:
        //        return (itemCategory == ItemCategory.Helmet);
        //    case EquipmentSlotType.Armor:
        //        return (itemCategory == ItemCategory.Armor);
        //    case EquipmentSlotType.Consumables:
        //        return (itemCategory == ItemCategory.Consumable);
        //    case EquipmentSlotType.Special:
        //        return (itemCategory == ItemCategory.Armor);
        //    default:
        //        return false;
        //}
    }

    public EquipmentSlot GetEquipmentSlot()
    {
        var activeInv = GameManager.TeamManager.heroes[GameManager.TeamManager.GetCurrentHeroId()].GetComponent<Inventory>();

        switch (slotType)
        {
            case EquipmentSlotType.MeleeWeapon:
                return activeInv.meleeWeapon;
            case EquipmentSlotType.RangeWeapon:
                return activeInv.rangeWeapon;
            case EquipmentSlotType.Helmet:
                return activeInv.helmet;
            case EquipmentSlotType.Armor:
                return activeInv.armor;
            case EquipmentSlotType.Consumables:
                return activeInv.consumable;
            case EquipmentSlotType.Special:
                return activeInv.special;
            default:
                Debug.LogError("nie ma takiego typu");
                return null;
        }
    }

    public void SetImage(Sprite image)
    {
        this.image.GetComponent<Image>().sprite = image;
    }

    public GameObject GetImage()
    {
        return this.image;
    }

    public GameObject GetIcon()
    {
        return this.icon;
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
