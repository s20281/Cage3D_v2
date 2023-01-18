using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour
{
    public List<CombatInfo> enemyInfos;
    public List<CombatInfo> heroInfos;
    public GameObject skillsPanel;
    public SkillUI skillUI;
    public List<SkillUI> skillsUI = new List<SkillUI>();
    public List<HealthBarUI> heroHealthBars;
    public List<HealthBarUI> enemyHealthBars;


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
            //heroHealthBars[character.position - 1].UpdateHealth(character.combatStats.health);
        }
        else
        {
            enemyInfos[character.position - 1].UpdateInfo(character.combatStats);
            //enemyHealthBars[character.position - 1].UpdateHealth(character.combatStats.health);
        }
    }

    public void FillSkills(CombatCharacter hero)
    {
        //skillsUI[0].SetActive(!hero.inventory.meleeWeapon.isEmpty);
        skillsUI[0].gameObject.SetActive(true);
        skillsUI[1].gameObject.SetActive(!hero.inventory.rangeWeapon.isEmpty);
        skillsUI[2].gameObject.SetActive(!hero.inventory.consumable.isEmpty);
        skillsUI[3].gameObject.SetActive(!hero.inventory.special.isEmpty && !hero.usedSpecialPower);
    }

}
