using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject player;


    private ResponseHandler responseHandler;
    private TypeWriterEffect typeWriterEffect;

    int counter = 0;


    void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject, Item objectToGet, GameObject doorToOpen, HeroData heroToAdd) 
    {
        player.GetComponent<PlayerMovement>().canMove = false;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject, objectToGet, doorToOpen, heroToAdd));

        if (counter == 0)
        {
            GameManager.UIManager.minimapUI.turnOffMinimap();
            counter++;
        }
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject, Item objectToGet, GameObject doorToOpen, HeroData heroToAdd)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typeWriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.Responses != null && dialogueObject.Responses.Length > 0) break;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        }


        if (objectToGet != null)
        {
            GameManager.TeamManager.tryAddItem(objectToGet);
            Debug.Log("Item added");
        }

        if (doorToOpen != null && doorToOpen.GetComponent<Door>()!=null)
        {
            Debug.Log("Otwórz drzwi");
            doorToOpen.GetComponent<Door>().Unlock();

        }

        if (heroToAdd!=null)
        {

            GameManager.TeamManager.AddHero(heroToAdd);

        }

        if (dialogueObject.name == "NextTime")
        {
            CloseDialogueBox();
        }
        else
        {
            if (dialogueObject.HasResponses)
            {
                responseHandler.ShowResponses(dialogueObject.Responses);
            }
            else
            {
                CloseDialogueBox();

                GameManager.UIManager.minimapUI.turnOnMinimap();
            }
        }
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        player.GetComponent<PlayerMovement>().canMove = true;
        textLabel.text = string.Empty;

        
    }
}
