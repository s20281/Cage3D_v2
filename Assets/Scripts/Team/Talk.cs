using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ImportanceType
    {
        Nic,
        Psychika,
        Si³a,
        Unik,
        Samotnik,
        DuszaTowarzystwa
    }

public class Talk : Interactable
{
    [SerializeField] private DialogueObject dialogue1;
    [SerializeField] private DialogueObject dialogue2;
    [SerializeField] private DialogueObject dialogueNoTalk;

    [SerializeField] private ImportanceType type;

    [SerializeField] private GameObject doorToOpen;
    [SerializeField] private GameObject prefabToFindStats;
    [SerializeField] private GameObject prefabToCompareStats;
    [SerializeField] private int prefferedMindPoints;

    public bool ifCanTalk = true;




    public override void Interact()
    {
        startTalking();

    }

    public void startTalking()
    {
    
       switch (type)
        {

            case ImportanceType.Nic:
                GameManager.UIManager.dialogueUI.ShowDialogue(dialogue1, null, doorToOpen, null, ifCanTalk, dialogueNoTalk, gameObject);
                ifCanTalk = false;
                break;
            case ImportanceType.Psychika:

                if (GameManager.PlayerManager.GetMindPoints() >= prefferedMindPoints)
                {
                    GameManager.UIManager.dialogueUI.ShowDialogue(dialogue1, null, doorToOpen, null, ifCanTalk, dialogueNoTalk, gameObject);
                    ifCanTalk = false;
                }
                else
                {
                    GameManager.UIManager.dialogueUI.ShowDialogue(dialogue2, null, doorToOpen, null, ifCanTalk, dialogueNoTalk, gameObject);
                    ifCanTalk = false;
                }
                break;
            case ImportanceType.Si³a:
                if (prefabToFindStats.GetComponent<CombatStats>().strength >= prefabToCompareStats.GetComponent<CombatStats>().strength)
                {
                    GameManager.UIManager.dialogueUI.ShowDialogue(dialogue1, null, doorToOpen, null, ifCanTalk, dialogueNoTalk, gameObject);
                    ifCanTalk = false;
                }
                else
                {
                    GameManager.UIManager.dialogueUI.ShowDialogue(dialogue2, null, doorToOpen, null, ifCanTalk, dialogueNoTalk, gameObject);
                    ifCanTalk = false;
                }
                break;
            case ImportanceType.Unik:
                if (prefabToFindStats.GetComponent<CombatStats>().dodge >= prefabToCompareStats.GetComponent<CombatStats>().dodge)
                {
                    GameManager.UIManager.dialogueUI.ShowDialogue(dialogue1, null, doorToOpen, null, ifCanTalk, dialogueNoTalk, gameObject);
                    ifCanTalk = false;
                }
                else
                {
                    GameManager.UIManager.dialogueUI.ShowDialogue(dialogue2, null, doorToOpen, null, ifCanTalk, dialogueNoTalk, gameObject);
                    ifCanTalk = false;
                }
                break;
            case ImportanceType.Samotnik:
                if (GameManager.TeamManager.heroes.Count < 4)
                {                 
                    GameManager.UIManager.dialogueUI.ShowDialogue(dialogue1, null, doorToOpen, null, ifCanTalk, dialogueNoTalk, gameObject);
                    ifCanTalk = false;
                }
                else
                {
                    GameManager.UIManager.dialogueUI.ShowDialogue(dialogue2, null, doorToOpen, null, ifCanTalk, dialogueNoTalk, gameObject);
                    ifCanTalk = false;
                }
                break;
            case ImportanceType.DuszaTowarzystwa:
                if (GameManager.TeamManager.heroes.Count >= 4)
                {
                    GameManager.UIManager.dialogueUI.ShowDialogue(dialogue1, null, doorToOpen, null, ifCanTalk, dialogueNoTalk, gameObject);
                    ifCanTalk = false;
                }
                else
                {
                    GameManager.UIManager.dialogueUI.ShowDialogue(dialogue2, null, doorToOpen, null, ifCanTalk, dialogueNoTalk, gameObject);
                    ifCanTalk = false;
                }
                break;
            
        }
    }
}
