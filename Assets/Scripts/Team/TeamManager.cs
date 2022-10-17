using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public List<GameObject> heroes = new List<GameObject>();
    private int currentHero;

    public GameObject currentHeroGO;

    [SerializeField]
    private GameObject heroPrefab;


    private void Start()
    {
        heroes = new List<GameObject>();

        foreach(Transform child in gameObject.transform)
        {
            heroes.Add(child.gameObject);
        }

        currentHeroGO = heroes[0];
    }

    public bool tryAddItem(Item item)
    {
        for(int i = 0; i < heroes.Count; i++)
        {
            if (heroes[i].GetComponent<Inventory>().AddItem(item))
                return true;
        }
        return false;
    }

    public void AddHero(HeroData heroData)
    {
        var newHero = Instantiate(heroPrefab, transform);
        newHero.GetComponent<Hero>().heroData = heroData;
        heroes.Add(newHero);
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
