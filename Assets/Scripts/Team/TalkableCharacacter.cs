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

              //jak b�dzie enum i b�dziemy wybiera� po ang to na podstawie tego mo�e zrobienie strength itp., podawa� w argumencie jak�
              //wielkosc statystyk8i chce dany bohater, albo ile razy wi�ksza od swojwj 

     }*/
}
