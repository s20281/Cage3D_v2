using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    private bool infoActive = false;
    private CombatStats stats;

    [SerializeField] private GameObject INFO;

    private void Start()
    {
        stats = GetComponent<CombatStats>();
    }
    private void OnMouseOver()
    {
        if (infoActive)
            return;
        infoActive = true;

        INFO.SetActive(true);
    }

    private void OnMouseExit()
    {
        infoActive = false;
        INFO.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!GameManager.CombatManager.skillSelected)
            return;

        GameManager.CombatManager.DeselectSkills();

        if(stats.health <= 0)
            INFO.SetActive(false);

    }
}
