using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Statistic
{
    maxHealth,
    accuracy,
    dodge,
    strength,
    speed
}
public class CombatStats : MonoBehaviour
{
    public string characterName;
    public int maxHealth;
    public int health;
    public int accuracy;
    public int dodge;
    public int strength;
    public int speed;
    public int armor;
    public int expForKill;

    //public void SetupStats(HeroData heroData)
    //{
    //    characterName = heroData.heroName;
    //    maxHealth = heroData.maxHealth;
    //    health = heroData.maxHealth;
    //    accuracy = heroData.accuracy;
    //    dodge = heroData.dodge;
    //    strength = heroData.strength;
    //    speed = heroData.speed;
    //}

    public void SetupStats(Hero hero)
    {
        GetComponent<CombatCharacter>().hero = hero;
        characterName = hero.heroName;
        maxHealth = hero.maxHealth;
        health = hero.maxHealth;
        accuracy = hero.accuracy;
        dodge = hero.dodge;
        strength = hero.strength;
        speed = hero.speed;
    }

    public void SetupStats(EnemyData enemyData)
    {
        characterName = enemyData.enemyName;
        maxHealth = enemyData.maxHealth;
        health = enemyData.maxHealth;
        accuracy = enemyData.accuracy;
        dodge = enemyData.dodge;
        strength = enemyData.strength;
        speed = enemyData.speed;
        expForKill = enemyData.expForKill;
    }

    public void ChangeHealth(int change)
    {
        var healthBar = GetComponent<CombatCharacter>().healthBarUI;

        if (change < 0)
        {
            change += armor;
            if (change > 0)
                change = 0;
        }

        healthBar.ShowChange(change);

        health += change;

        if(health <= 0)
        {
            health = 0;
            Die();
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthBar.UpdateHealth(health);
    }

    public void OnMiss()
    {
        var healthBar = GetComponent<CombatCharacter>().healthBarUI;
        healthBar.ShowMiss();
    }

    private void Die()
    {
        var character = GetComponent<CombatCharacter>();
        GameManager.UIManager.combatUI.SwitchInfo(character, false);
        GameManager.CombatManager.Turn.OnDead(character);
        if(!character.isHero)
        {
            GameManager.CombatManager.changePosition.enemyPositionOccupied[character.position - 1] = false;
            GameManager.CombatManager.currentCharacter.hero.AddExperience(expForKill);

            GameManager.PlayerManager.ChangeMindPoints(MindPointsActions.EnemyDied);
        } 
        else
        {
            if(characterName == "Player")
                GameManager.PlayerManager.ChangeMindPoints(MindPointsActions.PlayerDied);
            else
                GameManager.PlayerManager.ChangeMindPoints(MindPointsActions.HeroDied);
        }

        Destroy(gameObject);
        if (!character.isHero)
            GameManager.CombatManager.changePosition.OnEnemyDead();
    }
}
