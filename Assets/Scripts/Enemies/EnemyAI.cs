using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    public abstract CombatCharacter ChooseEnemy();
    public abstract CombatCharacter ChooseAlly();
    public abstract void Attack(CombatCharacter target);
    public abstract void SpecialAttack(CombatCharacter target);
    public abstract void SupportSkill(CombatCharacter target);
    public abstract void ChooseAction();
}
