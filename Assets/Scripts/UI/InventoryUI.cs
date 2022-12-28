using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public List<GameObject> inventorySlotsUI = new List<GameObject>();
    public List<GameObject> equipmentSlotsUI = new List<GameObject>();
    public int activeHero;

    public GameObject heldItemIcon;
    public bool holdingItem = true;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventorySlotsUI.Count; i++)
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

        if (holdingItem)
        {
            FollowMouse();
        }
    }

    [SerializeField] GameObject bagpackPanel;
    [SerializeField] GameObject equipmentPanel;
    [SerializeField] GameObject heroPanel;
    [SerializeField] GameObject skillsPanel;

    public void ToggleSkillInventory(bool inventory)
    {
        bagpackPanel.SetActive(inventory);
        equipmentPanel.SetActive(inventory);
        heroPanel.SetActive(!inventory);
        skillsPanel.SetActive(!inventory);

        if (!inventory)
            RefreshSkills();
    }

    [SerializeField] List<GameObject> addButtons;

    public void AddSkillPoint(int id)
    {
        GameManager.TeamManager.heroes[activeHero].GetComponent<Hero>();
    }


    private void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);

        if (inventoryPanel.activeSelf)
        {
            heroName.text = GameManager.TeamManager.currentHeroGO.GetComponent<Hero>().heroData.heroName;
            RefreshInventory();
            GameManager.PlayerManager.playerMovement.SwitchFreeze(true);
            GameManager.UIManager.minimapUI.ToggleMinimap();
            GameManager.UIManager.minimapUI.blockUnblockMapToggling();
        }
        else
        {
            GameManager.PlayerManager.playerMovement.SwitchFreeze(false);
            GameManager.UIManager.minimapUI.blockUnblockMapToggling();
            GameManager.UIManager.minimapUI.ToggleMinimap();

            RefreshSkills();

        }
    }

    [SerializeField] private TextMeshProUGUI healthValue;
    [SerializeField] private TextMeshProUGUI strengthValue;
    [SerializeField] private TextMeshProUGUI accuracyValue;
    [SerializeField] private TextMeshProUGUI dodgeValue;
    [SerializeField] private TextMeshProUGUI speedValue;

    [SerializeField] private Image portrait;
    [SerializeField] private TextMeshProUGUI levelValue;
    [SerializeField] private TextMeshProUGUI description;

    public void RefreshSkills()
    {
        var hero = GameManager.TeamManager.heroes[activeHero].GetComponent<Hero>();

        healthValue.text = hero.heroData.maxHealth.ToString();
        strengthValue.text = hero.heroData.strength.ToString();
        accuracyValue.text = hero.heroData.accuracy.ToString();
        dodgeValue.text = hero.heroData.dodge.ToString();
        speedValue.text = hero.heroData.speed.ToString();

        foreach (var addButton in addButtons)
        {
            addButton.SetActive(hero.skillPoints > 0);
        }

        levelValue.text = "Level: " + hero.level.ToString();
        description.text = hero.name.ToString();
        portrait.sprite = hero.heroData.portrait;
    }

    public void UseSkillPoint(int id)
    {
        var hero = GameManager.TeamManager.heroes[activeHero].GetComponent<Hero>();

        switch (id)
        {
            case 0:
                hero.heroData.maxHealth += 2;
                break;
            case 1:
                hero.heroData.strength += 1;
                break;
            case 2:
                hero.heroData.accuracy += 1;
                break;
            case 3:
                hero.heroData.dodge += 1;
                break;
            case 4:
                hero.heroData.speed += 1;
                break;          
        }
        hero.skillPoints--;
        RefreshSkills();
    }


    public void RefreshInventory()
    {
        var inv = GameManager.TeamManager.heroes[activeHero].GetComponent<Inventory>();

        for (int i = 0; i < inv.maxItemsCount; i++)
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

        for (int i = 0; i < equipmentSlotsUI.Count; i++)
        {
            var slot = equipmentSlotsUI[i].GetComponent<EquipmentSlotUI>();
            if (!slot.GetEquipmentSlot().isEmpty)
            {
                slot.icon.SetActive(false);
                slot.image.SetActive(true);
                slot.image.GetComponent<Image>().sprite = slot.GetEquipmentSlot().itemData.icon;
            }
            else
            {
                slot.icon.SetActive(true);
                slot.image.SetActive(false);
            }
        }

    }

    public GameObject GetEquipmentSlot(EquipmentSlot eqSlot)
    {
        var index = -1;
        switch (eqSlot.type)
        {
            case EquipmentSlotType.Helmet:
                index = 0;
                break;
            case EquipmentSlotType.Armor:
                index = 1;
                break;
            case EquipmentSlotType.MeleeWeapon:
                index = 2;
                break;
            case EquipmentSlotType.Consumables:
                index = 3;
                break;
            case EquipmentSlotType.Special:
                index = 4;
                break;
            case EquipmentSlotType.RangeWeapon:
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

    [SerializeField] private Text heroName;
    public void ChangeHeroLeft()
    {
        ChangeHero(-1);
    }
    public void ChangeHeroRight()
    {
        ChangeHero(1);
    }

    private void ChangeHero(int direction)
    {
        var nextHero = GameManager.TeamManager.GetCurrentHeroId() + direction;

        if (nextHero >= GameManager.TeamManager.heroes.Count)
        {
            nextHero = 0;
        }
        else if (nextHero < 0)
        {
            nextHero = GameManager.TeamManager.heroes.Count - 1;
        }

        GameManager.TeamManager.SetCurrentHeroId(nextHero);
        activeHero = nextHero;
        heroName.text = GameManager.TeamManager.heroes[nextHero].GetComponent<Hero>().heroData.heroName;
        RefreshInventory();
        RefreshSkills();
    }
}
