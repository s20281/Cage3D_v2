using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public List<GameObject> inventorySlotsUI = new List<GameObject>();
    public int ActiveInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ToggleInventory();

        if (Input.GetKeyDown(KeyCode.Escape) && inventoryPanel.activeSelf)
            ToggleInventory();
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
            //Debug.Log(inv.slots[i].isEmpty);

            if(!inv.slots[i].isEmpty)
            {
                inventorySlotsUI[i].transform.GetChild(1).gameObject.SetActive(true);
                inventorySlotsUI[i].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = inv.slots[i].itemData.icon;
            }
            else
            {
                inventorySlotsUI[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
}
