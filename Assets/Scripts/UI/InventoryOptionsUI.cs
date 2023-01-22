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
    private EquipmentSlot eqSlot;

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

        if (!GameManager.UIManager.inventoryUI.inventoryPanel.activeSelf)
        {
            optionsBox.gameObject.SetActive(false);
        }
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
        var activeHero = GameManager.TeamManager.heroes[GameManager.TeamManager.GetCurrentHeroId()];
        var activeInv = activeHero.GetComponent<Inventory>();
        var eqSlots = GameManager.UIManager.inventoryUI.equipmentSlotsUI;

        switch (optionName)
        {
            case "Usuñ":
                DeleteItem(activeInv, true);
                break;
            case "Przeczytaj":
                GameManager.UIManager.readUI.ReadStoryByString(activeInv.slots[slotID].itemData.prefab.GetComponent<Read>().getObject().Read);
                break;
            case "U¿yj":
                var consData = activeInv.slots[slotID].itemData as ConsumableData;
                changeHealth(consData, activeHero, activeInv);
                break;
            case "Wyposa¿":
                Equip(invUI, activeInv, eqSlots);
                break;
            case "Od³ó¿":
                Unequip(invUI, activeInv);
                break;
                /* case "Statystyki":
                     Debug.Log("Teraz statystyki");
                     break;*/

        }
    }

    public void changeHealth(ConsumableData consData, GameObject activeHero, Inventory activeInv)
    {
        var healthBefore = activeHero.GetComponent<Hero>().heroData.maxHealth;
        var recentHealth = healthBefore + consData.heal;
        activeHero.GetComponent<Hero>().health = recentHealth;
        Debug.Log(recentHealth);

        DeleteItem(activeInv, false);
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
        this.eqSlot = eqSlot;

        if (ID >= 0)
        {
            slotID = ID;
            var activeInv = GameManager.TeamManager.heroes[GameManager.TeamManager.GetCurrentHeroId()].GetComponent<Inventory>();
            category = activeInv.slots[slotID].itemCategory;
        }

        if (eqSlot != null && eqSlot.itemData!=null && !eqSlot.isEmpty)
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
                        Debug.Log("here");
                        var slotTypeName = slotType.name;

                        if ((slotTypeName.Contains("InventorySlot") && option.Equals("Od³ó¿")) || (!slotTypeName.Contains("InventorySlot") && option.Equals("Wyposa¿")))
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


    private void DeleteItem(Inventory activeInv, bool ifSpawn)
    {
        if (eqSlot == null)
        {
            activeInv.RemoveItem(slotID);

            if (ifSpawn)
            {
                SpawnItem(activeInv.slots[slotID].itemData.prefab);
            }

        }
        else
        {
            var itemRemoved = activeInv.RemoveEqItem(eqSlot);
            icon.SetActive(true);
            image.SetActive(false);

            if (ifSpawn)
            {
                SpawnItem(itemRemoved.prefab);
            }

        }


    }

    private void SpawnItem(GameObject prefab)
    {

        Debug.Log(prefab.name);

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

    private void Unequip(InventoryUI invUI, Inventory activeInv)
    {
        if (!eqSlot.isEmpty)
        {
            var ID = activeInv.FindFreeSlot();
            if (ID > -1)
            {


                invUI.heldItemIcon.GetComponent<HeldItem>().SetHeldItem(activeInv.RemoveEqItem(eqSlot), image);
                icon.SetActive(true);
                image.SetActive(false);

                var held = invUI.heldItemIcon.GetComponent<HeldItem>().GetHeldItem();
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
