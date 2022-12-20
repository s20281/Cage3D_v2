using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Jako ui obrazek ksi¹zki i tam a'la wpisany tekst do przeczytania???
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
        //GameManager.UIManager.minimapUI.blockUnblockMapToggling();

    }

    public void ReadStoryByString(string textToRead)
    {
        if (textLabel != null || textToRead != null)
        {
            gameObject.SetActive(true);

            textLabel.text = textToRead;
        }

        GameManager.UIManager.minimapUI.ToggleMinimap();
        //GameManager.UIManager.minimapUI.blockUnblockMapToggling();

    }


    void Update()
    {
        if (gameObject.active && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
            
           // GameManager.UIManager.minimapUI.blockUnblockMapToggling();
            GameManager.UIManager.minimapUI.ToggleMinimap();


        }

        
    }
}
