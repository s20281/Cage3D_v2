using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Response 
{
    [SerializeField] public string responseText;
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private Item objectToGet;
    [SerializeField] private Item objectToGive;
    [SerializeField] private HeroData heroToAdd;
    [SerializeField] private int impactOnMind;


    public string ResponseText => responseText;

    public DialogueObject DialogueObject => dialogueObject;
    public Item ObjectToGet => objectToGet;
    public Item ObjectToGive => objectToGive;
    public HeroData HeroToAdd => heroToAdd;
    public int ImpactOnMind => impactOnMind;
}
