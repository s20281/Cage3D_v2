using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public EnemyType enemyType;
    public GameObject combatPrefab;
    public int maxHealth;
    public int strength;
    public int accuracy;
    public int dodge;
    public int speed;
    public int expForKill;
    public int armor;
}

public enum EnemyType
{
    None,
    Skeleton,
    SkeletonBoss,
    ArmoredSkeleton,
    Archer,
    ArmoredArcher
}
