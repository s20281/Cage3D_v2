using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadUI : MonoBehaviour
{
    public TMP_Text textLabel;

    public void ReadStory(ReadObject textToRead)
    {
        if (textLabel != null || textToRead != null)
        {
            gameObject.SetActive(true);

            textLabel.text = textToRead.Read;
            
            GameManager.UIManager.minimapUI.turnOffMinimap();
        }
    }

    public void ReadStoryByString(string textToRead)
    {
        if (textLabel != null || textToRead != null)
        {
            gameObject.SetActive(true);

            textLabel.text = textToRead;
        }
        GameManager.UIManager.minimapUI.turnOffMinimap();
    }


    void Update()
    {
        if (gameObject.active && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);

            if (!GameManager.UIManager.inventoryUI.inventoryPanel.activeSelf)
            {
                GameManager.UIManager.minimapUI.turnOnMinimap();
            }
        }
    }
}
