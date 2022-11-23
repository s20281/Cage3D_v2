using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : EnemyAI
{
    public Animator animator;

    public override void Attack(CombatCharacter target)
    {
        target.combatStats.ChangeHealth(-1);
        animator.CrossFade("Attack2", 0.1f);
    }

    public override void ChooseAction()
    {
        var heroes = GameManager.CombatManager.Turn.aliveHeroes;
        Attack(heroes[Random.Range(0, heroes.Count)]);
    }

    public override CombatCharacter ChooseAlly()
    {
        throw new System.NotImplementedException();
    }

    public override CombatCharacter ChooseEnemy()
    {
        throw new System.NotImplementedException();
    }

    public override void SpecialAttack(CombatCharacter target)
    {
        throw new System.NotImplementedException();
    }

    public override void SupportSkill(CombatCharacter target)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
