using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MindPointsActions
{
    BattleWon,
    BattleLost,
    HeroDied,
    PlayerDied,
    EnemyDied
}

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private int mindPoints = 0;

    [SerializeField] private int battleWonPoints;
    [SerializeField] private int battleLostPoints;
    [SerializeField] private int heroDiedPoints;
    [SerializeField] private int playerDiedPoints;
    [SerializeField] private int enemyDiedPoints;


    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }

    public float DistanceFromPlayer(Vector3 position)
    {
        return Vector3.Distance(position, transform.position);
    }

    public int ChangeMindPoints(int pointToAdd)
    {
        return mindPoints += pointToAdd;
    }
    public void ChangeMindPoints(MindPointsActions action)
    {
        switch(action)
        {
            case MindPointsActions.BattleWon:
                mindPoints += battleWonPoints;
                return;

            case MindPointsActions.BattleLost:
                mindPoints += battleLostPoints;
                return;

            case MindPointsActions.HeroDied:
                mindPoints += heroDiedPoints;
                return;

            case MindPointsActions.PlayerDied:
                mindPoints += playerDiedPoints;
                return;

            case MindPointsActions.EnemyDied:
                mindPoints += enemyDiedPoints;
                return;
        }
    }

    public int GetMindPoints()
    {
        return mindPoints;
    }
}
