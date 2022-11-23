using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    private Animator heroAnimator;
    private Animator targetAnimator;
    private float animationTime = 0;
    public bool Use(CombatCharacter target)
    {
        if (target.isHero)
            return false;

        heroAnimator = GameManager.CombatManager.currentCharacter.GetComponent<Animator>();
        //targetAnimator = target.GetComponent<Animator>();

        //if(MeleeAttack)

        MeleeAttack(target);


        return true;
    }

    private void MeleeAttack(CombatCharacter target)
    {
        if(GameManager.CombatManager.currentCharacter.inventory.meleeWeapon.isEmpty)
        {
            heroAnimator.CrossFade("Hook Punch", 0.3f);
            animationTime = 1f; 
        }
        else if(GameManager.CombatManager.currentCharacter.position == 1)
        {
            heroAnimator.CrossFade("Slash4", 0.3f);
            animationTime = 1.5f;
        }
        else
        {
            heroAnimator.CrossFade("Slash", 0.3f);
            animationTime = 0.5f;
        }

        StartCoroutine(Effect(animationTime, target));
    }

    private IEnumerator Effect(float time, CombatCharacter target)
    {
        yield return new WaitForSeconds(animationTime);
        var effect = Instantiate(GameManager.FXSpawner.HitWhite, target.transform);
        effect.transform.localScale = Vector3.one * 1;
        effect.transform.localPosition = new Vector3(0.25f, 1.5f, 0);
        effect.transform.parent = null;
        MeleeAttackEffect(target);
        GameManager.UIManager.combatUI.UpdateInfo(target);
    }


    private void MeleeAttackEffect(CombatCharacter target)
    {
        var character = GameManager.CombatManager.currentCharacter;
        int damage = character.combatStats.strength;
        if(character.isHero && !character.inventory.meleeWeapon.isEmpty)
        {
            damage += (character.inventory.meleeWeapon.itemData as WeaponData).baseDamage;
        }

        int positionDiff = character.position - 1 + target.position - 1;
        float penaltyFactor = positionDiff * 0.1f;

        print("Damage1: " + damage);

        damage = (int)(damage * (1 - penaltyFactor));

        print("Damage2: " + damage);

        target.combatStats.ChangeHealth(-damage);
    }

    private void RangeAttack()
    {

    }

}
