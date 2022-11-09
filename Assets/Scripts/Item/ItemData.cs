using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{
    public ItemCategory itemCategory;
    public int id;
    public string name;
    public Sprite icon;
    
    public bool singleUse;
    public GameObject prefab;
}


public enum ItemCategory
{
    None,
    Key,
    Readable,
    Consumable,
    MeleeWeapon,
    Armor,
    Helmet,
    RangeWeapon,
    Special
}
