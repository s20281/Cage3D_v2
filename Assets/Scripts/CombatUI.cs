using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour
{
    public List<CombatInfo> enemyInfos;
    public List<CombatInfo> heroInfos;


    public void SwitchInfo(bool hero, int position, bool activate)
    {
        if(hero)
        {
            heroInfos[position-1].gameObject.SetActive(activate);
        }
        else
        {
            enemyInfos[position-1].gameObject.SetActive(activate);
        }
    }

    public void UpdateInfo(bool hero, int position, CombatStats combatStats)
    {
        if (hero)
        {
            heroInfos[position - 1].UpdateInfo(combatStats);
        }
        else
        {
            enemyInfos[position - 1].UpdateInfo(combatStats);
        }
    }
}
