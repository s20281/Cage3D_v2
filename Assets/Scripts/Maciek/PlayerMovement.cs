using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public float movementSpeed;

    private float defaultSpeed = 400f;
    private float sprintSpeed = 600f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire3"))
            movementSpeed = sprintSpeed;
        else
            movementSpeed = defaultSpeed;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRigidbody.velocity = new Vector3(horizontalInput, 0, verticalInput) * movementSpeed * Time.deltaTime;
    }
}
