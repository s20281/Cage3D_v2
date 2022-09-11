using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public bool isOpened;
    private bool needsKey;
    private Animator animator;

    public FogOfWar fowInRoom;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (isOpened)
            Close();
        else
            Open();
    }

    private void Open()
    {
        animator.Play("Open");
        isOpened = true;

        if (fowInRoom.isEnabled)
            fowInRoom.Switch(false);
    }

    private void Close()
    {
        animator.Play("Close");
        isOpened = false;
    }
}
