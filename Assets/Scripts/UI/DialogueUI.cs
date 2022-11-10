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
    /*
     private GameObject objectToAddToTeam;
     private string goodAnswer;
     private bool canBeRecruited;
     private GameObject gm;*/

    // private bool ifHaveImpactOnMind;
    // private int pointsToImpactTheMind;
    // private Villager villager;
    // private Hero prefabToFindStats;

    void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject, Item objectToGet, GameObject doorToOpen, HeroData heroToAdd) //to powinno mieæ wiêcej var by siê zmatchowa³o z responsami? za pierwszym razem by nulle przekazywa³o
    {
        player.GetComponent<PlayerMovement>().canMove = false;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject, objectToGet, doorToOpen, heroToAdd));
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
