using UnityEngine;

public class TalkableCharacter : Interactable
{
    public override void Interact()
    {

    }


    /* [SerializeField] private Hero findStats;
     [SerializeField] private Hero prefabWhichWantToCompareStats;*/


    /*  public void starTalking()
     {

         dialogUI.ShowDialogue(dialogue1, null, null, null);

         // dialogUI.GetObject(objectToDrop, objectWanted, canBeRecruited, doorToOpen, gameObject, ifHaveImpactOnMind, pointsToImpactTheMind, prefabToFindStats);

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

     }*/
}
