using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    public float followSpeed;
    public float rotateSpeed;
    public float zoomSpeed;

    public float height;

    // Start is called before the first frame update
    void Start()
    {
        height = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, player.transform.position + new Vector3(0,height,0), followSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -1 * rotateSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, 1 * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && height > 5)
        {
            height -= Time.deltaTime * zoomSpeed;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0 && height < 20)
        {
            height += Time.deltaTime * zoomSpeed;
        }
    }

    public Vector3 transormDirection(Vector3 direction)
    {
        return transform.TransformDirection(direction);
    }

}
