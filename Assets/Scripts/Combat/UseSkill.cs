using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    public void Use(CombatCharacter target)
    {
        if (target.isHero)
            return;
        var animator = GameManager.CombatManager.currentCharacter.GetComponent<Animator>();
        animator.CrossFade("SwordHit2", 0.3f);
        AnimatorStateInfo animState = animator.GetCurrentAnimatorStateInfo(0);
        float animTime = animState.normalizedTime % 1;
        StartCoroutine(Effect(animTime, target));
    }

    private IEnumerator Effect(float time, CombatCharacter target)
    {
        yield return new WaitForSeconds(time);
        target.combatStats.ChangeHealth(-5);
        GameManager.UIManager.combatUI.UpdateInfo(target);
    }
}
