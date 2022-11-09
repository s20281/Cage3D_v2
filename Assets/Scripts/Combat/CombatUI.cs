using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour
{
    public List<CombatInfo> enemyInfos;
    public List<CombatInfo> heroInfos;
    public SkillUI skillUI;


    public void SwitchInfo(CombatCharacter character, bool activate)
    {
        if(character.isHero)
        {
            heroInfos[character.position - 1].gameObject.SetActive(activate);
        }
        else
        {
            enemyInfos[character.position - 1].gameObject.SetActive(activate);
        }
    }

    public void UpdateInfo(CombatCharacter character)
    {
        if (character.isHero)
        {
            heroInfos[character.position - 1].UpdateInfo(character.combatStats);
        }
        else
        {
            enemyInfos[character.position - 1].UpdateInfo(character.combatStats);
        }
    }
}
