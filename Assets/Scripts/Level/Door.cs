using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public bool isOpened;
    private bool needsKey;
    private Animator animator;
    private bool onCooldown = false;
    private float cooldown = 1f;

    public FogOfWar fowInRoom;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (onCooldown)
            return;

        if (isOpened)
            Close();
        else
            Open();

        StartCoroutine(Cooldown());
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

    private IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
}
