using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CameraManager cameraManager;

    public static PlayerManager PlayerManager;
    public PlayerManager playerManager;
   //playerManager -> playerManager

    private void Awake()
    {
        instance = this;
    }

}
