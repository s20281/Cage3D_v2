using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hero : MonoBehaviour
{
    public HeroData heroData;

    public string heroName;
    public int experience = 0;
    public int level = 0;
    public int skillPoints = 0;

    public int maxHealth;
    public int health;
    public int strength;
    public int accuracy;
    public int dodge;
    public int speed;

    public void LoadStats()
    {
        heroName = heroData.heroName;
        maxHealth = heroData.maxHealth;
        health = maxHealth;
        strength = heroData.strength;
        accuracy = heroData.accuracy;
        dodge = heroData.dodge;
        speed = heroData.speed;
    }

    public void AddExperience(int exp)
    {
        experience += exp;

        var expForNextLevel = (level + 1) * 10;

        if(experience >= expForNextLevel)
        {
            experience -= expForNextLevel;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        skillPoints++;
    }
}
