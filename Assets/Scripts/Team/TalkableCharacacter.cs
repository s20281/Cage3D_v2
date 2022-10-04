using UnityEngine;

public class TalkableCharacter : Interactable
{
    [SerializeField] private DialogueUI dialogUI;

    [SerializeField] private DialogueObject dialogue1;
    [SerializeField] private DialogueObject dialogue2;
    

    [SerializeField] private GameObject objectToGive;
    
/*  
    [SerializeField] private bool ifHaveImpactOnMind; // to z mind te¿ pewnie mo¿na po³¹czyæ
    [SerializeField] private int pointsToImpactTheMind;

    [SerializeField] private Hero findStats;
    [SerializeField] private Hero prefabWhichWantToCompareStats;*/

    public override void Interact()
    {
        starTalking();

    }


    public void starTalking()
    {

        dialogUI.ShowDialogue(dialogue1, null, null);

        /* dialogUI.GetObject(objectToDrop, objectWanted, canBeRecruited, doorToOpen, gameObject, ifHaveImpactOnMind, pointsToImpactTheMind, prefabToFindStats);

         if (prefabToFindStats != null)
         {
             Character character = TeamDatabase.control.GetCharacter(prefabWhichWantToCompareStats.name.ToLower());
             var countCharactersInInventory = 0;

             foreach (var hero in Inventory.control.GetAllCharacters())
             {
                 if (hero.name != "blank")
                 {
                     Debug.Log(hero.name);
                     countCharactersInInventory++;
                 }
             }
             Debug.Log(character.whatWantInTeammates);

             //jak bêdzie enum i bêdziemy wybieraæ po ang to na podstawie tego mo¿e zrobienie strength itp., podawaæ w argumencie jak¹
             //wielkosc statystyk8i chce dany bohater, albo ile razy wiêksza od swojwj 
             switch (character.whatWantInTeammates)
             {


                 case "psychika":

                     if (prefabToFindStats.health > prefabWhichWantToCompareStats.health)
                     {
                         dialogUI.ShowDialogue(dialogue1);
                     }
                     else
                     {
                         dialogUI.ShowDialogue(dialogue2);
                     }

                     break;
                 case "si³a":
                     if (prefabToFindStats.strength > prefabWhichWantToCompareStats.strength)
                     {
                         dialogUI.ShowDialogue(dialogue1);
                     }
                     else
                     {
                         dialogUI.ShowDialogue(dialogue2);
                     }
                     break;
                 case "zrêcznoœæ":
                     if (prefabToFindStats.dodge > prefabWhichWantToCompareStats.dodge)
                     {
                         dialogUI.ShowDialogue(dialogue1);
                     }
                     else
                     {
                         dialogUI.ShowDialogue(dialogue2);
                     }
                     break;
                 case "wantToDisapear":
                     if (countCharactersInInventory > 4)
                     {
                         Debug.Log("powy¿ej 4 ludzi? Mam nadziejê ¿e nie bêdê musia³ czêsto wlaczyc");
                         dialogUI.ShowDialogue(dialogue1);
                     }
                     else
                     {
                         Debug.Log("Za ma³o ludzi");
                         dialogUI.ShowDialogue(dialogue2);
                     }
                     break;
                 case "wantToStandout":
                     if (countCharactersInInventory <= 4)
                     {
                         Debug.Log("4 ludzi, chcê ci¹gle walczyæ");
                         dialogUI.ShowDialogue(dialogue1);
                     }
                     else
                     {
                         Debug.Log("Za duzo ludzi");
                         dialogUI.ShowDialogue(dialogue2);
                     }
                     break;
             }




         }
         else
         {
             if (objectWanted != null && Inventory.control.FindItem(objectWanted.name) != null)
             {
                 dialogUI.ShowDialogue(dialogue2);

             }
             else
             {
                 dialogUI.ShowDialogue(dialogue1);
             }

         }
        */


    }
}
