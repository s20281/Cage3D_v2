using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootManager : MonoBehaviour
{
    [SerializeField] private Image lootImage;


    [SerializeField] List<Item> lootableItems = new List<Item>();

    public void RandomLoot()
    {
        var item = lootableItems[Random.Range(0, lootableItems.Count)];
        GameManager.TeamManager.tryAddItem(item);


        lootImage.sprite = item.itemData.icon;
        lootImage.gameObject.SetActive(true);
        Invoke(nameof(TurnOffImage), 3);
    }

    private void TurnOffImage()
    {
        lootImage.gameObject.SetActive(false);
    }

}
