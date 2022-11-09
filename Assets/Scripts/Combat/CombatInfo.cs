using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatInfo : MonoBehaviour
{
    public Text characterName;
    public Text health;
    public Text strength;
    public Text accuracy;
    public Text dodge;
    public Text speed;

    public void UpdateInfo(CombatStats stats)
    {
        characterName.text = stats.characterName;
        health.text = stats.health.ToString();
        strength.text = stats.strength.ToString();
        accuracy.text = stats.accuracy.ToString();
        dodge.text = stats.dodge.ToString();
        dodge.text = stats.dodge.ToString();
    }
}
