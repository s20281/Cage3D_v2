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
    private bool fightOver;
    public bool actionTaken;

    public void StartCombat()
    {
        fightOver = false;
        FillQueue();
        StartCoroutine(TurnFlow());
    }

    private void FillQueue()
    {
        if(aliveHeroes.Count == 0)
        {
            Debug.Log("Przegrana");
        }
        if (aliveEnemies.Count == 0)
        {
            Debug.Log("Wygrana");
        }

        charactersQueue = new SpeedQueue(minSpeedRoll, maxSpeedRoll);
        charactersQueue.EnqueueAll(aliveHeroes);
        charactersQueue.EnqueueAll(aliveEnemies);

        //print("Queue:");
        //while (charactersQueue.Count > 0)
        //{
        //    var character = charactersQueue.Dequeue();
        //    print(character.name);
        //}
    }
    public void OnDead(CombatCharacter character)
    {
        charactersQueue.RemoveCharacter(character);

        if (character.isHero)
        {
            aliveHeroes.Remove(character);
            if (aliveHeroes.Count == 0)
                fightOver = true;
        }
        else
        {
            aliveEnemies.Remove(character);
            if (aliveEnemies.Count == 0)
                fightOver = true;
        }   
    }

    private IEnumerator TurnFlow()
    {
        while (!fightOver)
        {
            if (aliveHeroes.Count == 0)
            {
                fightOver = true;
                break;
            }
                

            if (charactersQueue.Count == 0)
                FillQueue();

            var currentCharacter = charactersQueue.Dequeue();
            GameManager.CombatManager.currentCharacter = currentCharacter;
            currentCharacter.GetComponent<Outline>().enabled = true;

            GameManager.UIManager.combatUI.skillsPanel.SetActive(currentCharacter.isHero);
            

            if (!currentCharacter.isHero)
            {
                actionTaken = false;
                currentCharacter.enemyAI.ChooseAction();
                yield return new WaitUntil(() => actionTaken);
                yield return new WaitForSeconds(1);
            }
                
            else
            {
                GameManager.UIManager.combatUI.FillSkills(currentCharacter);
                actionTaken = false;
                yield return new WaitUntil(() => actionTaken);
                yield return new WaitForSeconds(1);
            }
            currentCharacter.TryGetComponent<Outline>(out var outline);
            if(outline != null)
                outline.enabled = false;
            GameManager.CombatManager.currentCharacter = null;
        }
        if (aliveEnemies.Count == 0)
        {
            print("VICTORY");
            GameManager.PlayerManager.ChangeMindPoints(MindPointsActions.BattleWon);
            GameManager.CombatManager.LootManager.RandomLoot();
        }
            
        else
        {
            Debug.Log("DEFEAT");
            GameManager.PlayerManager.ChangeMindPoints(MindPointsActions.BattleLost);
        }
            
        yield return new WaitForSeconds(1);
        GameManager.CombatManager.EndCombat();
    }
}
