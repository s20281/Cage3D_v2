using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public FollowPlayer followPlayer;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject combatCamera;


    public void SwitchCamera(bool toCombat)
    {
        mainCamera.SetActive(!toCombat);
        combatCamera.SetActive(toCombat);
    }

}
