using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacter : MonoBehaviour
{
    public bool isHero;
    public int position;
    private bool infoActive = false;
    private Outline outline;
    private CombatStats combatStats;

    private void Start()
    {
        outline = GetComponent<Outline>();
        combatStats = GetComponent<CombatStats>();
    }

    private void OnMouseOver()
    {
        if (infoActive)
            return;
        infoActive = true;

        GameManager.UIManager.combatUI.UpdateInfo(isHero, position, combatStats);
        GameManager.UIManager.combatUI.SwitchInfo(isHero, position, true);
        outline.enabled = true;
        //UpdateInfo();
    }

    private void OnMouseExit()
    {
        infoActive = false;
        GameManager.UIManager.combatUI.SwitchInfo(isHero, position, false);
        outline.enabled = false;
    }

    private void OnMouseDown()
    {
        if (!GameManager.CombatManager.skillSelected)
            return;
        GameManager.CombatManager.DeselectSkills();
    }
}
