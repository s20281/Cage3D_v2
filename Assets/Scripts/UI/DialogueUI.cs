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
    /* private GameObject objectToGet;
     private GameObject objectToGive;
     private GameObject objectToAddToTeam;
     private string goodAnswer;
     private bool canBeRecruited;
     private bool shouldOpenTheDoor;
     private GameObject doorToOpen;
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
        // gm = GameObject.FindGameObjectWithTag("GM");
    }

    public void ShowDialogue(DialogueObject dialogueObject, GameObject objectToGet, GameObject doorToOpen) //to powinno mieæ wiêcej var by siê zmatchowa³o z responsami? za pierwszym razem by nulle przekazywa³o
    {
        player.GetComponent<PlayerMovement>().canMove = false;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    /*
     *     [SerializeField] private GameObject objectToGive;
    [SerializeField] private GameObject objectToGet;
    [SerializeField] private GameObject doorToOpen;
    [SerializeField] private enum addToTeam { Yes, No, NoNeed};
     */

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typeWriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.Responses != null && dialogueObject.Responses.Length > 0) break;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        }


        /* if (dialogueObject.objectToGet != null)
           {
               player.GetComponent<Inventory>().AddItem(objectToGet.name);
               gm.gameObject.GetComponent<Inventory2>().items.Add(objectToDrop.GetComponent<PickableItem>().item);
           }



           if (objectWanted != null)
           {
               player.GetComponent<Inventory>().RemoveItem(objectWanted.name);
               gm.gameObject.GetComponent<Inventory2>().items.Remove(objectWanted.GetComponent<PickableItem>().item);
           }


           //Object door not null
           if (doorToOpen != null)
           {
               if (doorToOpen.GetComponent<Door>() != null) // i czy ju¿ nie odblokowane
               {
                   Debug.Log("Open");
                   doorToOpen.GetComponent<Door>().doorOpening(); //skrypt który odblokowywuje drzwi
               }
           }


           //tutaj ju¿ dodajemy do dru¿yny ludzi
           //sprawdzamy czy canBerecruited i czy w response jest addToTeam: tak/true (mo¿e tu daæ 3 staty tak nie i brak info) wtedy dodajemy
           if (canBeRecruited && dialogueObject.name.ToLower() == goodAnswer.ToLower())
           {
               Debug.Log("pick");
               objectToAddToTeam.GetComponent<PickableItem>().PickItem(player.GetComponent<Inventory>());

               if (ifHaveImpactOnMind == true && prefabToFindStats != null)
               {
                   prefabToFindStats.mentalHealth += pointsToImpactTheMind;
               }



           }
           else //addTo Team: nie
           {
               objectToAddToTeam.SetActive(false);
               objectToAddToTeam.GetComponent<ObjectsManager>().setOff();


               if (ifHaveImpactOnMind)
               {
                   prefabToFindStats.mentalHealth -= pointsToImpactTheMind;
               }
           }*/

        if (dialogueObject.name == "NextTime") // to mo¿e byæ przed wziêciem do dru¿yny. ZObaczymy jak wyjdzie w praniu.
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

    /* public void GetObject(GameObject objectToGet, GameObject objectToGive,string goodAnswer, bool canBeRecruited, bool shouldOpenTheDoor, GameObject doorToOpen, GameObject objectToAddToTeam, bool ifHaveImpactOnMind, int pointsToImpactTheMind, Hero heroToStats)
     {

         this.objectToGet = objectToGet;
         this.objectToGive = objectToGive;
         this.goodAnswer = goodAnswer;
         this.canBeRecruited = canBeRecruited;
         this.shouldOpenTheDoor = shouldOpenTheDoor;
         this.doorToOpen = doorToOpen;
         this.objectToAddToTeam = objectToAddToTeam;
         this.ifHaveImpactOnMind = ifHaveImpactOnMind;
         this.pointsToImpactTheMind = pointsToImpactTheMind;
         this.prefabToFindStats = heroToStats;
     }*/
}
