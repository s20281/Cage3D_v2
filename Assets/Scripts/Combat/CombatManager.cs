using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private bool combatActive = false;
    public bool skillSelected = false;
    public CombatCharacter currentCharacter;
    [SerializeField] private GameObject combatUI;
    [SerializeField] private Transform skills;
    [SerializeField] private LoadCharacters loadCharacters;
    public ChangePosition changePosition;
    public LoadCharacters LoadCharacters => loadCharacters;
    [SerializeField] private Turn turn;
    public Turn Turn => turn;
    [SerializeField] private UseSkill useSkill;
    public UseSkill UseSkill => useSkill;
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
    }

    public void EndCombat()
    {
        combatActive = false;
        GameManager.CameraManager.SwitchCamera(false);
        GameManager.PlayerManager.playerMovement.SwitchFreeze(false);
        combatUI.SetActive(false);
    }

    public void DeselectSkills()
    {
        foreach(Transform skill in skills)
        {
            skill.gameObject.GetComponent<SkillUI>().Deselect();
        }
        skillSelected = false;
    }
}
