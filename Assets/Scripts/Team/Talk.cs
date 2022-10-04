using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : Interactable
{
    [SerializeField] private DialogueObject dialogue1;
    [SerializeField] private DialogueObject dialogue2;

    [SerializeField] private GameObject objectToGive;
    [SerializeField] private bool canBeRecruited;

    public override void Interact()
    {
        starTalking();

    }

    public void starTalking()
    {
        GameManager.UIManager.dialogueUI.ShowDialogue(dialogue1, null, null);
    }
}
