using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public List<HeroData> heroDatas;
    public List<GameObject> heroes = new List<GameObject>();
    private int currentHero;

    public GameObject currentHeroGO;

    [SerializeField]
    private GameObject heroPrefab;


    private void Start()
    {
        heroes = new List<GameObject>();

        //foreach (Transform child in gameObject.transform)
        //{
        //    heroes.Add(child.gameObject);
        //}

        AddHero(heroDatas[0]); // Dodanie G³ównego Bohatera
        AddHero(heroDatas[1]); // Dodanie Ninjy

        currentHeroGO = heroes[0];
    }

    public bool tryAddItem(Item item)
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            if (heroes[i].GetComponent<Inventory>().AddItem(item))
                return true;
        }
        return false;
    }

    public bool tryRemoveItem(Item item)
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            if (heroes[i].GetComponent<Inventory>().RemoveItemFromInventory(item))
                return true;
        }
        return false;
    }

    public void AddHero(HeroData heroData)
    {
        var newHero = Instantiate(heroPrefab, transform);
        newHero.name = heroData.heroName;
        var hero = newHero.GetComponent<Hero>();
        hero.heroData = heroData;
        hero.LoadStats();
        heroes.Add(newHero);
        GameManager.UIManager.inventoryUI.teamPlacing.AddHeroPortrait(hero);
    }

    public int GetCurrentHeroId()
    {
        return currentHero;
    }

    public void SetCurrentHeroId(int id)
    {
        currentHero = id;
        currentHeroGO = heroes[id];
    }

}
