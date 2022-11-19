using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField]
    private Image outline;
    private bool selected = false;

    private Color32 normal = new Color32(73, 54, 46, 255);
    private Color32 active = new Color32(188, 185, 0, 255);
    private Color32 activeFaded = new Color32(188, 185, 0, 155);

    private void Start()
    {
        outline.color = normal;
    }

    public void Select()
    {
        if (selected)
        {
            Deselect();
            GameManager.CombatManager.skillSelected = false;
            return;
        }
        selected = true;
        GameManager.CombatManager.skillSelected = true;
        outline.color = active;
        StartCoroutine(Pulsing());
    }

    public void Deselect()
    {
        selected = false;
        StopAllCoroutines();
        outline.color = normal;
    }

    IEnumerator Pulsing()
    {
        float time = 1f;
        while(selected)
        {
            float timer = 0;
            while (timer < time)
            {
                outline.color = Color32.Lerp(active, activeFaded, timer / time);
                timer += Time.deltaTime;
                yield return null;
            }
            timer = 0;
            while (timer < time)
            {
                outline.color = Color32.Lerp(activeFaded, active, timer / time);
                timer += Time.deltaTime;
                yield return null;
            } 
        }
        outline.color = normal;
    }


}
