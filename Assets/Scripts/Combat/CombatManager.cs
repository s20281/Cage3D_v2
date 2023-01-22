using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private bool combatActive = false;
    public bool isSkillSelected = false;
    public bool agressiveSkill;
    public Skill selectedSkill;
    public CombatCharacter currentCharacter;
    [SerializeField] private GameObject combatUI;
    [SerializeField] private Transform skills;
    [SerializeField] private LoadCharacters loadCharacters;
    public LootManager LootManager;
    public ChangePosition changePosition;
    public LoadCharacters LoadCharacters => loadCharacters;
    [SerializeField] private Turn turn;
    public Turn Turn => turn;
    [SerializeField] private UseSkill useSkill;
    public UseSkill UseSkill => useSkill;

    public bool CombatAvtive()
    {
        return combatActive;
    }
        

    public void StartCombat(List<EnemyData> enemies)
    {
        if (combatActive)
            return;
        combatActive = true;
        print("COMBAT");

        loadCharacters.SpawnHeros();
        loadCharacters.SpawnEnemies(enemies);
        turn.StartCombat();
        GameManager.CameraManager.SwitchCamera(true);
        GameManager.PlayerManager.playerMovement.SwitchFreeze(true);
        combatUI.SetActive(true);
        GameManager.UIManager.minimapUI.SwtichMinimap(false);
    }

    public void EndCombat()
    {
        combatActive = false;
        GameManager.CameraManager.SwitchCamera(false);
        GameManager.PlayerManager.playerMovement.SwitchFreeze(false);
        combatUI.SetActive(false);
        GameManager.UIManager.minimapUI.SwtichMinimap(true);
    }

    public void DeselectSkills()
    {
        foreach(Transform skill in skills)
        {
            skill.gameObject.GetComponent<SkillUI>().Deselect();
        }
        isSkillSelected = false;
    }
}
