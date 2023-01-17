using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private Animator animator;
    public override void Interact()
    {
        animator.Play("OpenChest");
        blockInteract = true;   
    }
}
