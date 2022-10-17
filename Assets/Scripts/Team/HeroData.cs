using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero")]
public class HeroData : ScriptableObject
{
    public string name;
    public int maxHealth;
}
