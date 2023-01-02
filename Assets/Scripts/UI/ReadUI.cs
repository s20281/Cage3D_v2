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
        }

        GameManager.UIManager.minimapUI.ToggleMinimap();
        GameManager.UIManager.minimapUI.turnOffMinimap();

    }

    public void ReadStoryByString(string textToRead)
    {
        if (textLabel != null || textToRead != null)
        {
            gameObject.SetActive(true);

            textLabel.text = textToRead;
        }

        GameManager.UIManager.minimapUI.ToggleMinimap();
        GameManager.UIManager.minimapUI.turnOffMinimap();

    }


    void Update()
    {
        if (gameObject.active && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);

            GameManager.UIManager.minimapUI.turnOnMinimap();
            //jeszczer doda� sprawdzenie czy jest aktywny inny ui (g��wnie inv)
            GameManager.UIManager.minimapUI.ToggleMinimap();


        }

        
    }
}
