using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }

    public float DistanceFromPlayer(Vector3 position)
    {
        return Vector3.Distance(position, transform.position);
    }
}
