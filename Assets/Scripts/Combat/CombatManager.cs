using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private bool combatActive = false;
    public bool skillSelected = false;

    [SerializeField] private GameObject combatUI;
    [SerializeField] private Transform skills;
    public void StartCombat(List<int> enemiesIDs)
    {
        if (combatActive)
            return;
        combatActive = true;
        print("COMBAT");
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
