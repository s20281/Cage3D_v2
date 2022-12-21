using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    private Animator heroAnimator;
    private Animator targetAnimator;
    private float animationTime = 0;
    public bool Use(CombatCharacter user, CombatCharacter target)
    {
        if (GameManager.CombatManager.agressiveSkill && target.isHero || !GameManager.CombatManager.agressiveSkill && !target.isHero)
            return false;

        heroAnimator = GameManager.CombatManager.currentCharacter.GetComponent<Animator>();
        //targetAnimator = target.GetComponent<Animator>();

        switch(GameManager.CombatManager.selectedSkill)
        {
            case Skill.MeleeAttack:
                MeleeAttack(user, target);
                break;
            case Skill.RangeAttack:
                RangeAttack(user, target);
                break;
            case Skill.Consumable:
                Consumable(user, target);
                break;
            case Skill.Special:
                SpecialSkill(user, target);
                break;
        }

        GameManager.UIManager.combatUI.skillsPanel.SetActive(false);
        return true;
    }

    private void MeleeAttack(CombatCharacter user, CombatCharacter target)
    {
        if (user.inventory.meleeWeapon.isEmpty)
        {
            heroAnimator.CrossFade("Hook Punch", 0.3f);
            animationTime = 1f;
            GameManager.SoundManager.Invoke(nameof(GameManager.SoundManager.PlayWhoosh), 0.75f);
            GameManager.SoundManager.Invoke(nameof(GameManager.SoundManager.PlayPunch), 1f);
        }
        else if(user.position == 1)
        {
            heroAnimator.CrossFade("Slash4", 0.3f);
            animationTime = 1.5f;
            GameManager.SoundManager.Invoke(nameof(GameManager.SoundManager.PlayWhoosh), 1f);
            GameManager.SoundManager.Invoke(nameof(GameManager.SoundManager.PlaySlash), 1.5f);
        }
        else
        {
            heroAnimator.CrossFade("Slash", 0.3f);
            animationTime = 0.5f;
            GameManager.SoundManager.Invoke(nameof(GameManager.SoundManager.PlayWhoosh), 0.25f);
            GameManager.SoundManager.Invoke(nameof(GameManager.SoundManager.PlaySlash), 0.5f);
        }
        StartCoroutine(Effect(animationTime, user, target));
    }

    private void RangeAttack(CombatCharacter user, CombatCharacter target)
    {
        var weaponID = user.inventory.rangeWeapon.itemData.id;
        if(weaponID == 1)
        {

        }
        else if (weaponID == 6)
        {
            heroAnimator.CrossFade("Shooting", 0.3f);
            animationTime = 0.85f;
            GameManager.SoundManager.Invoke(nameof(GameManager.SoundManager.PlayLaserShot), 0.85f);
            GameManager.SoundManager.Invoke(nameof(GameManager.SoundManager.PlayBulletImpact), 0.85f);
        }
        StartCoroutine(Effect(animationTime, user, target));
    }


    private IEnumerator Effect(float time, CombatCharacter user, CombatCharacter target)
    {
        yield return new WaitForSeconds(animationTime);
        var effect = Instantiate(GameManager.FXSpawner.HitWhite, target.transform);
        effect.transform.localScale = Vector3.one * 1;
        effect.transform.localPosition = new Vector3(0.25f, 1.5f, 0);
        effect.transform.parent = null;

        switch (GameManager.CombatManager.selectedSkill)
        {
            case Skill.MeleeAttack:
                MeleeAttackEffect(user, target);
                break;
            case Skill.RangeAttack:
                RangeAttackEffect(user, target);
                break;
        }
        
        GameManager.UIManager.combatUI.UpdateInfo(target);
        GameManager.CombatManager.Turn.actionTaken = true;
    }


    private void MeleeAttackEffect(CombatCharacter user, CombatCharacter target)
    {
        int damage = user.combatStats.strength;

        print("user: " + user.name + " / " + user.isHero + " - " + user.position);

        print("strength: " + user.combatStats.strength);

        if(user.isHero && !user.inventory.meleeWeapon.isEmpty)
        {
            damage += (user.inventory.meleeWeapon.itemData as WeaponData).baseDamage;
            print("base: " + (user.inventory.meleeWeapon.itemData as WeaponData).baseDamage);
        }

        int positionDiff = user.position - 1 + target.position - 1;
        float penaltyFactor = positionDiff * 0.1f;

        print("Damage1: " + damage);

        damage = (int)(damage * (1 - penaltyFactor));

        print("Damage2: " + damage);

        target.combatStats.ChangeHealth(-damage);
    }

    private void RangeAttackEffect(CombatCharacter user, CombatCharacter target)
    {
        int damage = user.combatStats.accuracy;

        if (user.isHero && !user.inventory.rangeWeapon.isEmpty)
        {
            damage += (user.inventory.rangeWeapon.itemData as WeaponData).baseDamage;
        }

        int positionDiff = user.position - 1 + target.position - 1;
        int maxPositonDiff = 6;
        float penaltyFactor = (positionDiff - maxPositonDiff) * 0.1f;

        damage = (int)(damage * (1 - penaltyFactor));

        target.combatStats.ChangeHealth(-damage);
    }

    private void Consumable(CombatCharacter user, CombatCharacter target)
    {
        var consData = user.inventory.consumable.itemData as ConsumableData;

        if (consData.heal > 0)
        {
            target.combatStats.ChangeHealth(consData.heal);
            // VFX
            // SFX
        }
        GameManager.CombatManager.Turn.actionTaken = true;
    }

    private void SpecialSkill(CombatCharacter user, CombatCharacter target)
    {

        GameManager.CombatManager.Turn.actionTaken = true;
    }

}
