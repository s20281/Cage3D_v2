using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour
{
    public List<CombatInfo> enemyInfos;
    public List<CombatInfo> heroInfos;
    public GameObject skills;
    public SkillUI skillUI;
    [SerializeField]
    private List<GameObject> skillsUI = new List<GameObject>();


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

    public void FillSkills(CombatCharacter hero)
    {
        //skillsUI[0].SetActive(!hero.inventory.meleeWeapon.isEmpty);
        skillsUI[0].SetActive(true);
        skillsUI[1].SetActive(!hero.inventory.rangeWeapon.isEmpty);
    }

}
