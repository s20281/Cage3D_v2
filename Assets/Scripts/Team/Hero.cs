using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hero : MonoBehaviour
{
    public HeroData heroData;

    public int experience = 0;
    public int level = 0;
    public int skillPoints = 0;



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
