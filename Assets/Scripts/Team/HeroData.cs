using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/HeroData")]
public class HeroData : ScriptableObject
{
    public string heroName;
    public int maxHealth;
    public int strength;
    public int accuracy;
    public int dodge;
    public int speed;
    public GameObject combatPrefab;
}
