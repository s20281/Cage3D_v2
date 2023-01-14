using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField] List<Item> lootableItems = new List<Item>();

    public void RandomLoot()
    {
        var item = lootableItems[Random.Range(0, lootableItems.Count)];
        GameManager.TeamManager.tryAddItem(item);
    }

}
