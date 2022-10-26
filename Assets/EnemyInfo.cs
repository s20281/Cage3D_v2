using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    private bool infoActive = false;
    private Stats stats;

    [SerializeField] private GameObject INFO;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }


    private void OnMouseOver()
    {
        if (infoActive)
            return;
        infoActive = true;

        UpdateInfo();
        INFO.SetActive(true);
    }

    private void OnMouseExit()
    {
        infoActive = false;
        INFO.SetActive(false);
    }

    private void UpdateInfo()
    {
        INFO.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = stats.health.ToString();
        INFO.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.GetComponent<Text>().text = stats.strength.ToString();
        INFO.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.GetComponent<Text>().text = stats.accuary.ToString();
        INFO.transform.GetChild(1).GetChild(3).GetChild(1).gameObject.GetComponent<Text>().text = stats.dodge.ToString();
        INFO.transform.GetChild(1).GetChild(4).GetChild(1).gameObject.GetComponent<Text>().text = stats.speed.ToString();
    }

    private void OnMouseDown()
    {
        if (!GameManager.CombatManager.skillSelected)
            return;

        GameManager.CombatManager.DeselectSkills();

        stats.ChangeHealth(-5);

        if(stats.health <= 0)
            INFO.SetActive(false);

        UpdateInfo();
    }
}
