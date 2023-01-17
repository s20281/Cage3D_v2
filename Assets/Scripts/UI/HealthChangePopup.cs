using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthChangePopup : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI changeText;

    public void ShowChange(float change)
    {
        if(change < 0)
            changeText.colorGradient = new VertexGradient(Color.red, Color.red, Color.black, Color.black);
        else if(change > 0)
            changeText.colorGradient = new VertexGradient(Color.green, Color.green, Color.black, Color.black);
        else
            changeText.colorGradient = new VertexGradient(Color.yellow, Color.yellow, Color.black, Color.black);

        changeText.text = Mathf.Abs(change).ToString();
        animator.Play("Show");
    }
}
