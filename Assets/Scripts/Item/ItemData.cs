using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class ItemData : ScriptableObject
{
    public ItemCategory itemCategory;
    public int id;
    public string name;
    public Sprite icon;
    
    public bool singleUse;
    public GameObject prefab;
}

public class WeaponData : ItemData
{
    public float baseDamage;
    //public Skill skill;
}


public enum ItemCategory
{
    Weapon,
    Key,
    Readable,
    Consumable,
    None
}
