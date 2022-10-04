using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Response 
{
    [SerializeField] public string responseText;
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private GameObject objectToGet;
    [SerializeField] private GameObject doorToOpen;
   // [SerializeField] private enum AddToTeam { Yes, No, NoNeed};


    public string ResponseText => responseText;

    public DialogueObject DialogueObject => dialogueObject;
    public GameObject GameObject => objectToGet;
    public GameObject GameObject2 => doorToOpen;
   // public AddToTeam AddToTeam1 => addToTeam;
}
