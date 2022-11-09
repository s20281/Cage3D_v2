using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacter : MonoBehaviour
{
    public bool isHero;
    public int position;
    private bool infoActive = false;
    private Outline outline;
    public CombatStats combatStats => GetComponent<CombatStats>();

    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    private void OnMouseOver()
    {
        if (infoActive)
            return;
        infoActive = true;

        GameManager.UIManager.combatUI.UpdateInfo(this);
        GameManager.UIManager.combatUI.SwitchInfo(this, true);
        outline.enabled = true;
        //UpdateInfo();
    }

    private void OnMouseExit()
    {
        infoActive = false;
        GameManager.UIManager.combatUI.SwitchInfo(this, false);
        outline.enabled = false;
    }

    private void OnMouseDown()
    {
        if (!GameManager.CombatManager.skillSelected)
        {
            return;
        }

        GameManager.CombatManager.UseSkill.Use(this);
        GameManager.CombatManager.DeselectSkills();
    }
}
