using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public float movementSpeed;
    public Animator animator;

    private float defaultSpeed = 400f;
    private float sprintSpeed = 600f;
    public float rotationSpeed = 6;
    private float sprintRotationSpeed = 9;

    public Collider headCollider;


    public Transform cameraTripod;
    public Vector3 target;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire3"))
            movementSpeed = sprintSpeed;
        else
            movementSpeed = defaultSpeed;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 target = new Vector3(horizontalInput, 0, verticalInput);
        target = GameManager.instance.cameraManager.followPlayer.transormDirection(target);

        playerRigidbody.velocity = target * movementSpeed * Time.deltaTime;


        if (horizontalInput != 0 || verticalInput != 0)
        {
            var lookRotation = Quaternion.LookRotation(target);
            headCollider.enabled = true;

            if (Input.GetButton("Fire3"))
            {
                animator.Play("Sprint");
                
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * sprintRotationSpeed);
            }

            else
            {
                animator.Play("RunForward");
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            }   
        }
        else
        {
            headCollider.enabled = false;
            animator.Play("Idle");
        }
    }
}
