using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpeedQueue
{
    private int minRoll;
    private int maxRoll;

    public SpeedQueue(int minRoll, int maxRoll)
    {
        this.minRoll = minRoll;
        this.maxRoll = maxRoll;
    }

    private Dictionary<CombatCharacter, int> characters = new Dictionary<CombatCharacter, int>();
    public int Count => characters.Count;

    public void Enqueue(CombatCharacter character)
    {
        int baseSpeed = character.combatStats.speed;
        int rolledSpeed = Random.Range(minRoll, maxRoll + 1);
        characters.Add(character, baseSpeed + rolledSpeed);
    }

    public void EnqueueAll(ICollection<CombatCharacter> charactersCollection)
    {
        foreach(var character in charactersCollection)
        {
            int baseSpeed = character.combatStats.speed;
            int rolledSpeed = Random.Range(minRoll, maxRoll + 1);
            characters.Add(character, baseSpeed + rolledSpeed);
        }
    }

    public CombatCharacter Dequeue()
    {
        int maxSpeed = int.MinValue;
        CombatCharacter fastestCharacter = characters.First<KeyValuePair<CombatCharacter, int>>().Key;

        foreach(KeyValuePair<CombatCharacter, int> character in characters)
        {
            if(character.Value > maxSpeed)
            {
                maxSpeed = character.Value;
                fastestCharacter = character.Key;
            }
        }

        characters.Remove(fastestCharacter);
        return fastestCharacter;
    }
       
}
