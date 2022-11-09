using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField] private int minSpeedRoll;
    [SerializeField] private int maxSpeedRoll;

    private SpeedQueue charactersQueue;
    public List<CombatCharacter> aliveHeroes = new List<CombatCharacter>();
    public List<CombatCharacter> aliveEnemies = new List<CombatCharacter>();

    public void StartCombat()
    {
        FillQueue();
    }

    private void FillQueue()
    {
        if(aliveHeroes.Count < 0)
        {
            Debug.Log("Przegrana");
        }
        if (aliveEnemies.Count < 0)
        {
            Debug.Log("Wygrana");
        }

        charactersQueue = new SpeedQueue(minSpeedRoll, maxSpeedRoll);
        charactersQueue.EnqueueAll(aliveHeroes);
        charactersQueue.EnqueueAll(aliveEnemies);

        print("Queue:");
        while (charactersQueue.Count > 0)
        {
            var character = charactersQueue.Dequeue();
            print(character.name);
        }
    }


}
