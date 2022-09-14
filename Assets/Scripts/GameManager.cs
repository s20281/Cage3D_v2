using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CameraManager cameraManager;

    public static PlayerManager PlayerManager;
    public PlayerManager playerManager;

    public static TeamManager TeamManager;
    public TeamManager teamManager;

    public UIManager UIManager;


    private void Awake()
    {
        instance = this;
    }

}
