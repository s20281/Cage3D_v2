using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Read : Interactable
{

    [SerializeField] private ReadObject textToRead;

    public override void Interact()
    {
        GameManager.UIManager.readUI.ReadStory(textToRead);
    }



}
