using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionButton : MonoBehaviour
{
    private string name;

    private void Start()
    {
        name = gameObject.GetComponent<TMP_Text>().text;

    }

    public void OnPressed()
    {
        GameManager.UIManager.inventoryOptionsUI.OnPressed(name);
    }

}
