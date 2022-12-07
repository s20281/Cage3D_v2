using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarPoint : MonoBehaviour
{
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;
    [SerializeField] private Image image;

    public bool isActive = true;
    public int index;

    public void SwitchColor()
    {
        if (isActive)
            StartCoroutine(LerpColor(activeColor, inactiveColor));
        else
            StartCoroutine(LerpColor(inactiveColor, activeColor));

        isActive = !isActive;
    }
    
    private IEnumerator LerpColor(Color a, Color b)
    {
        float timer = 0;
        float time = 0.5f;

        while(timer < time)
        {
            image.color = Color.Lerp(a, b, timer / time);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
