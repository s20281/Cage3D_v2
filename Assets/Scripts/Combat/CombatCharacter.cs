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
    public Inventory inventory;
    public HeroData heroData;
    public Hero hero;
    public WeaponHolder weaponHolder;
    public EnemyAI enemyAI;
    public HealthBarUI healthBarUI;

    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    private void OnMouseOver()
    {
        if (infoActive)
            return;
        infoActive = true;

        //GameManager.UIManager.combatUI.UpdateInfo(this);
        //GameManager.UIManager.combatUI.SwitchInfo(this, true);
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        infoActive = false;
        GameManager.UIManager.combatUI.SwitchInfo(this, false);

        if(GameManager.CombatManager.currentCharacter != this)
            outline.enabled = false;
    }

    private void OnMouseDown()
    {
        if (!GameManager.CombatManager.isSkillSelected)
        {
            return;
        }

        if(GameManager.CombatManager.UseSkill.Use(GameManager.CombatManager.currentCharacter, this))
        {
            GameManager.CombatManager.DeselectSkills();
        }
            
    }
}
