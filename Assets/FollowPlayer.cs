using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    public float followSpeed;

    private Vector3 cadre;


    // Start is called before the first frame update
    void Start()
    {
        cadre = new Vector3(0, 14, -1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, player.transform.position + cadre, followSpeed * Time.deltaTime);
    }
}
