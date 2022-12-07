using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> weapons = new List<GameObject>();

    public void SwitchWeapons()
    {
        var id = -1;
        switch (GameManager.CombatManager.selectedSkill)
        {
            case Skill.MeleeAttack:
                if(!GameManager.CombatManager.currentCharacter.inventory.meleeWeapon.isEmpty)
                    id = GameManager.CombatManager.currentCharacter.inventory.meleeWeapon.itemData.id;
                break;
            case Skill.RangeAttack:
                if (!GameManager.CombatManager.currentCharacter.inventory.rangeWeapon.isEmpty)
                    id = GameManager.CombatManager.currentCharacter.inventory.rangeWeapon.itemData.id;
                break;
        }

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(id == i);
        }
    }


    public void SwitchWeapons(int id)
    {
        for(int i = 0; i< weapons.Count; i++)
        {
            weapons[i].SetActive(id == i);
        }
    }

}
