using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    public bool Use(CombatCharacter target)
    {
        if (target.isHero)
            return false;
        var animator = GameManager.CombatManager.currentCharacter.GetComponent<Animator>();
        animator.CrossFade("SwordHit2", 0.3f);
        AnimatorStateInfo animState = animator.GetCurrentAnimatorStateInfo(0);
        float animTime = animState.normalizedTime % 1;
        StartCoroutine(Effect(animTime, target));
        return true;
    }

    private IEnumerator Effect(float time, CombatCharacter target)
    {
        yield return new WaitForSeconds(time);
        MeleeAttack(target);
        GameManager.UIManager.combatUI.UpdateInfo(target);
    }


    private void MeleeAttack(CombatCharacter target)
    {
        var character = GameManager.CombatManager.currentCharacter;
        int damage = character.combatStats.strength;
        if(character.isHero && !character.inventory.meleeWeapon.isEmpty)
        {
            damage += (character.inventory.meleeWeapon.itemData as WeaponData).baseDamage;
        }

        target.combatStats.ChangeHealth(-damage);
    }

    private void RangeAttack()
    {

    }

}
