using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Layer
{
    Default,
    TransparentFX,
    IgnoreRaycast,
    Player,
    Water,
    UI,
    Interactable
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static CameraManager CameraManager => Instance.cameraManager;
    public CameraManager cameraManager;

    public static PlayerManager PlayerManager => Instance.playerManager;
    public PlayerManager playerManager;

    public static TeamManager TeamManager => Instance.teamManager;
    public TeamManager teamManager;

    public static UIManager UIManager => Instance.uIManager;
    public UIManager uIManager;

    public static CombatManager CombatManager => Instance.combatManager;
    public CombatManager combatManager;

    public static FXSpawner FXSpawner => Instance.FXspawner;
    public FXSpawner FXspawner;


    private void Awake()
    {
        Instance = this;
    }

}
