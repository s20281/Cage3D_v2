using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamPlacing : MonoBehaviour
{
    public List<TeamSlot> teamSlots;

    [SerializeField] GameObject heroPortraitPrefab;


    Dictionary<Hero, GameObject> heroPortraits = new Dictionary<Hero, GameObject>();


    public void AddHeroPortrait(Hero hero)
    {
        var newPortrait = Instantiate(heroPortraitPrefab, transform);
        newPortrait.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-360, 360), Random.Range(-200, -100), 0);
        newPortrait.GetComponent<DragHeroes>().SetupHero(hero);
        heroPortraits.Add(hero, newPortrait);
    }

    public void RemoveHeroPortrait(Hero hero)
    {
        var portraitToRemove = heroPortraits[hero];
        heroPortraits.Remove(hero);
        Destroy(portraitToRemove);
    }

}
