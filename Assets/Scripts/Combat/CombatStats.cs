using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStats : MonoBehaviour
{
    public string characterName;
    public int maxHealth;
    public int health;
    public int accuracy;
    public int dodge;
    public int strength;
    public int speed;

    public void SetupStats(HeroData heroData)
    {
        characterName = heroData.heroName;
        maxHealth = heroData.maxHealth;
        health = heroData.maxHealth;
        accuracy = heroData.accuracy;
        dodge = heroData.dodge;
        strength = heroData.strength;
        speed = heroData.speed;
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
    }

    public void ChangeHealth(int change)
    {
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
    }

    private void Die()
    {
        var character = GetComponent<CombatCharacter>();
        GameManager.UIManager.combatUI.SwitchInfo(character, false);
        GameManager.CombatManager.Turn.OnDead(character);

        GameManager.CombatManager.changePosition.enemyPositionOccupied[character.position - 1] = false;

        Destroy(gameObject);
        
        GameManager.CombatManager.changePosition.OnEnemyDead();
    }
}
