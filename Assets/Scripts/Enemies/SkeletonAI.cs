using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : EnemyAI
{
    public Animator animator;
    CombatCharacter target;
    public CombatStats combatStats;

    private void Start()
    {
        combatStats = GetComponent<CombatStats>();
    }

    public override void Attack(CombatCharacter target)
    {
        this.target = target;
        animator.CrossFade("Attack2", 0.1f);
        StartCoroutine(AttackEffect());
    }

    private IEnumerator AttackEffect()
    {
        var combatCharacter = GetComponent<CombatCharacter>();
        if (UseSkill.HitOrMiss(combatCharacter, target, true))
        {
            yield return new WaitForSeconds(1.5f);

            var effect = Instantiate(GameManager.FXSpawner.HitWhite, target.transform);
            effect.transform.localScale = Vector3.one;
            effect.transform.localPosition = new Vector3(0.25f, 1.5f, 0);
            effect.transform.parent = null;
            target.combatStats.ChangeHealth(-combatStats.strength);
            GameManager.UIManager.combatUI.UpdateInfo(target);

            if (target.combatStats.armor > 0)
                GameManager.SoundManager.PlayArmorHit();
            else
                GameManager.SoundManager.PlayPunch();

        }
        GameManager.CombatManager.Turn.actionTaken = true;
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
}
