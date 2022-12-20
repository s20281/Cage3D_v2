using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private List<BarPoint> healthPoints = new List<BarPoint>();
    private List<Image> armorPoints = new List<Image>();
    public GameObject healthPointPrefab;
    public GameObject armorPointPrefab;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject armorBar;

    public void OnEnterCombat(CombatCharacter character)
    {
        SetupHealth(character.combatStats.health);
        SetupArmor(character.combatStats.armor);
    }

    private void SetupHealth(int healthCount)
    {
        healthPoints.Clear();
        foreach (Transform healthPoint in healthBar.transform)
            Destroy(healthPoint.gameObject);

        for(int i = 0; i< healthCount; i++)
        {
            var hp = Instantiate(healthPointPrefab, healthBar.transform);
            var barPoint = hp.GetComponent<BarPoint>();
            healthPoints.Add(barPoint);
            barPoint.index = i;
        }
    }

    private void SetupArmor(int armorCount)
    {
        armorBar.SetActive(armorCount > 0);
        if (armorCount <= 0)
            return;

        armorPoints.Clear();
        foreach (Transform armorPoint in armorBar.transform)
            Destroy(armorPoint.gameObject);

        for (int i = 0; i < armorCount; i++)
        {
            var ap = Instantiate(armorPointPrefab, armorBar.transform);
            armorPoints.Add(ap.GetComponent<Image>());
        }
    }

    public void UpdateHealth(int currentHealth)
    {
        if(currentHealth <= 0)
        {
            return;
        }

        for(int i = 0; i< healthPoints.Count; i++)
        {
            if (currentHealth < i+1 && healthPoints[i].isActive || currentHealth >= i+1 && !healthPoints[i].isActive)
                healthPoints[i].SwitchColor();
        }
    }

}