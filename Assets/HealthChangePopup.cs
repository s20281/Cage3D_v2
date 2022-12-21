using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthChangePopup : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI changeText;

    private Color red = new Color(255,0,0);
    private Color green = new Color(0, 255, 0);
    private Color black = new Color(0, 0, 0);



    public void ShowChange(float change)
    {
        if(change < 0)
            changeText.colorGradient = new VertexGradient(red, Color.red, black, Color.black);
        else if(change > 0)
            changeText.colorGradient = new VertexGradient(green, Color.green, black, Color.black);
        else
            changeText.colorGradient = new VertexGradient(Color.yellow, Color.yellow, Color.black, Color.black);

        changeText.text = Mathf.Abs(change).ToString();
        animator.Play("Show");
    }
}
