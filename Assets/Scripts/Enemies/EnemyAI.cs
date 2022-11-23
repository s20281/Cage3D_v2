using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract CombatCharacter ChooseEnemy();
    public abstract CombatCharacter ChooseAlly();
    public abstract void Attack(CombatCharacter target);
    public abstract void SpecialAttack(CombatCharacter target);
    public abstract void SupportSkill(CombatCharacter target);
    public abstract void ChooseAction();
}
