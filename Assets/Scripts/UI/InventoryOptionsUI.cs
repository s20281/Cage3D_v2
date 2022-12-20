using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryOptionsUI : MonoBehaviour
{
    [SerializeField] private RectTransform optionsBox;
    [SerializeField] private RectTransform optionButtonTemplate;
    [SerializeField] private RectTransform optionsContainer;

    private List<GameObject> tempOptionsButtons = new List<GameObject>();
    public Dictionary<string, List<PossibleOptionEnum>> dictio = new Dictionary<string, List<PossibleOptionEnum>>();
    private int slotID;
    private GameObject icon;
    private GameObject image;

    private void Start()
    {
        optionsBox.gameObject.SetActive(false);

        dictio.Add("Readable", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Przeczytaj });
        dictio.Add("Consumable", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.U¿yj, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿ });
        dictio.Add("MeleeWeapon", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿ });
        dictio.Add("Armor", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿ });
        dictio.Add("Helmet", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿ });
        dictio.Add("RangeWeapon", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿ });
        dictio.Add("Special", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿ });
    }

    /* JAK BÊD¥ STATYSTYKI
      private void Start()
    {
        optionsBox.gameObject.SetActive(false);

        dictio.Add("Readable", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Przeczytaj });
        dictio.Add("Consumable", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.U¿yj, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿ });
        dictio.Add("MeleeWeapon", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿, PossibleOptionEnum.Statystyki });
        dictio.Add("Armor", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿, PossibleOptionEnum.Statystyki });
        dictio.Add("Helmet", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿, PossibleOptionEnum.Statystyki });
        dictio.Add("RangeWeapon", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿, PossibleOptionEnum.Statystyki });
        dictio.Add("Special", new List<PossibleOptionEnum>() { PossibleOptionEnum.Usuñ, PossibleOptionEnum.Wyposa¿, PossibleOptionEnum.Od³ó¿, PossibleOptionEnum.Statystyki });
    }
     */


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && optionsBox.gameObject.activeSelf)
            ToggleInventoryOptions();
    }

    public void SetPosition(Vector3 mousePos)
    {
        optionsBox.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    private void ToggleInventoryOptions()
    {
        optionsBox.gameObject.SetActive(!optionsBox.gameObject.activeSelf);
    }

    public void OnPressed(string optionName)
    {
        ToggleInventoryOptions();
        var invUI = GameManager.UIManager.inventoryUI;
        var activeInv = GameManager.TeamManager.heroes[GameManager.TeamManager.GetCurrentHeroId()].GetComponent<Inventory>();
        var eqSlots = GameManager.UIManager.inventoryUI.equipmentSlotsUI;


        switch (optionName)
        {
            case "Usuñ":
                DeleteItem(activeInv);
                break;
            case "Przeczytaj":
                Debug.Log("TEKST PONI¯EJ DO UI:    " + activeInv.slots[slotID].itemData.prefab.GetComponent<Read>().getObject().Read);
                GameManager.UIManager.readUI.ReadStoryByString(activeInv.slots[slotID].itemData.prefab.GetComponent<Read>().getObject().Read);
                break;
            case "U¿yj":
                Debug.Log("Teraz u¿yj:");
                break;
            case "Wyposa¿":
                Equip(invUI, activeInv, eqSlots);
                break;
            case "Od³ó¿":
                Unequip(invUI, activeInv, eqSlots);
                break;
                /* case "Statystyki":
                     Debug.Log("Teraz statystyki");
                     break;*/

        }
    }



    public void SetEquipmentSlotsInfo(GameObject icon, GameObject image)
    {
        this.icon = icon;
        this.image = image;
    }

    public void SetInventorySlotInfo(GameObject icon)
    {
        this.icon = icon;
    }

    private void Clear()
    {
        foreach (GameObject go in tempOptionsButtons)
        {
            Destroy(go);
        }

    }

    public void ShowOptions(int ID, GameObject slotType, EquipmentSlot eqSlot)
    {
        Clear();
        float optionBoxHeight = 0;
        string[] allOptions = System.Enum.GetNames(typeof(PossibleOptionEnum));
        ItemCategory category = ItemCategory.None;

        if (ID >= 0)
        {
            slotID = ID;
            var activeInv = GameManager.TeamManager.heroes[GameManager.TeamManager.GetCurrentHeroId()].GetComponent<Inventory>();
            category = activeInv.slots[slotID].itemCategory;
        }

        if (eqSlot != null)
        {
            category = eqSlot.itemData.itemCategory;
        }


        if (dictio.ContainsKey(category.ToString()))
        {
            var dictionaryOptions = dictio[category.ToString()];

            foreach (string option in allOptions)
            {
                foreach (PossibleOptionEnum dictOpt in dictionaryOptions)
                {
                    if (option.Equals(dictOpt.ToString()))
                    {

                        var slotTypeName = slotType.name;

                        if ((slotTypeName.Equals("InventorySlot") && option.Equals("Od³ó¿")) || (slotTypeName.Equals("EquipmentSlot") && option.Equals("Wyposa¿")))
                        {
                            break;
                        }

                        GameObject optionButton = Instantiate(optionButtonTemplate.gameObject, optionsContainer);
                        optionButton.gameObject.SetActive(true);
                        optionButton.GetComponent<TMP_Text>().text = option;

                        tempOptionsButtons.Add(optionButton);

                        optionBoxHeight += optionButtonTemplate.sizeDelta.y + 6;

                    }
                }

            }

            optionsBox.sizeDelta = new Vector2(optionsBox.sizeDelta.x, optionBoxHeight);
            optionButtonTemplate.sizeDelta = new Vector2(optionsBox.sizeDelta.x, optionButtonTemplate.sizeDelta.y);
            ToggleInventoryOptions();
        }
    }


    private void DeleteItem(Inventory activeInv)
    {
        activeInv.RemoveItem(slotID);
        SpawnItem(activeInv.slots[slotID].itemData.prefab);

    }

    private void SpawnItem(GameObject prefab)
    {

        if (prefab != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 playerCordinates = player.transform.position;
            Vector3 itemPosition = new Vector3(playerCordinates.x + 3, playerCordinates.y, playerCordinates.z);
            Instantiate(prefab, itemPosition, Quaternion.identity);
        }



    }

    private void Equip(InventoryUI invUI, Inventory activeInv, List<GameObject> eqSlots)
    {

        invUI.heldItemIcon.GetComponent<HeldItem>().SetHeldItem(activeInv.RemoveItem(slotID), icon);


        foreach (GameObject slot in eqSlots)
        {

            var eqSlot = slot.GetComponent<EquipmentSlotUI>().GetEquipmentSlot();
            var eqSlotType = slot.GetComponent<EquipmentSlotUI>().slotType;


            if (eqSlot.isEmpty && slot.GetComponent<EquipmentSlotUI>().CanEquip())
            {
                var held = invUI.heldItemIcon.GetComponent<HeldItem>().GetHeldItem();
                activeInv.SetEqItem(held, eqSlot);
                icon.SetActive(false);

                slot.GetComponent<EquipmentSlotUI>().SetImage(held.itemData.icon);

                slot.GetComponent<EquipmentSlotUI>().GetImage().SetActive(true);

                GameManager.UIManager.inventoryUI.RefreshInventory();

            }
        }

    }

    private void Unequip(InventoryUI invUI, Inventory activeInv, List<GameObject> eqSlots)
    {
        foreach (GameObject slot in eqSlots)
        {

            var eqSlot = slot.GetComponent<EquipmentSlotUI>().GetEquipmentSlot();
            var eqSlotType = slot.GetComponent<EquipmentSlotUI>().slotType;

            if (!eqSlot.isEmpty)
            {
                invUI.heldItemIcon.GetComponent<HeldItem>().SetHeldItem(activeInv.RemoveEqItem(eqSlot), image);
                icon.SetActive(true);
                image.SetActive(false);

                var held = invUI.heldItemIcon.GetComponent<HeldItem>().GetHeldItem();
                var ID = activeInv.FindFreeSlot();
                activeInv.AddItem(held, ID);
                GameManager.UIManager.inventoryUI.RefreshInventory();



            }
        }

    }

}

public enum PossibleOptionEnum
{
    Usuñ,
    Przeczytaj,
    U¿yj,
    Wyposa¿,
    Od³ó¿,
    Statystyki,
}
