using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public List<GameObject> heroes = new List<GameObject>();
    public int currentHero;

    public bool tryAddItem(Item item)
    {
        for(int i = 0; i < heroes.Count; i++)
        {
            if (heroes[i].GetComponent<Inventory>().AddItem(item))
                return true;
        }
        return false;
    }
}
