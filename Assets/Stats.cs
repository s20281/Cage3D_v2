using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int accuary;
    public int dodge;
    public int strength;
    public int speed;


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
        Destroy(gameObject);
        print("dead");
    }
}
