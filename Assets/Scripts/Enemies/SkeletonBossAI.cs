using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBossAI : EnemyAI
{
    public Animator animator;
    CombatCharacter target;
    public CombatStats combatStats;
    public CombatCharacter combatCharacter;

    [SerializeField] EnemyData armoredSkeleton;

    private int specialCooldown = 2;
    private int currentCooldown = 0;

    public override void Attack(CombatCharacter target)
    {
        var combatCharacter = GetComponent<CombatCharacter>();

        this.target = target;
        animator.CrossFade("Attack2", 0.1f);

        if (UseSkill.HitOrMiss(combatCharacter, target, true))
        {
            Invoke(nameof(AttackEffect), 1.5f);
        }
    }

    private void AttackEffect()
    {
        var effect = Instantiate(GameManager.FXSpawner.HitWhite, target.transform);
        effect.transform.localScale = Vector3.one;
        effect.transform.localPosition = new Vector3(0.25f, 1.5f, 0);
        effect.transform.parent = null;
        target.combatStats.ChangeHealth(-combatStats.strength);
        GameManager.UIManager.combatUI.UpdateInfo(target);
    }

    private IEnumerator SummonAlies()
    {
        GameManager.CombatManager.changePosition.MoveBack(combatCharacter);
        yield return new WaitForSeconds(1);

        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1);
            var spawned = GameManager.CombatManager.LoadCharacters.SummonEnemy(armoredSkeleton);

            if(spawned)
            {
                combatStats.armor -= 2;
                combatCharacter.healthBarUI.UpdateArmor(combatStats.armor);
            }
            else
            {
                yield break;
            }
            yield return new WaitForSeconds(1);
        }
    }

    public override void ChooseAction()
    {
        if (GameManager.CombatManager.Turn.aliveEnemies.Count < 4 && currentCooldown == 0)
        {
            StartCoroutine(SummonAlies());
            currentCooldown = specialCooldown + 1;
        }
        else
        {
            var heroes = GameManager.CombatManager.Turn.aliveHeroes;
            Attack(heroes[Random.Range(0, heroes.Count)]);
        }

        currentCooldown--;
        if (currentCooldown < 0)
            currentCooldown = 0;
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
