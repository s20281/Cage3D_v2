using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacters : MonoBehaviour
{
    public List<GameObject> heroPrefabs = new List<GameObject>();

    public List<Transform> heroPositions = new List<Transform>();
    public List<Transform> enemyPositions = new List<Transform>();

    public void SpawnEnemies(List<EnemyData> enemies)
    {
        GetComponent<Turn>().aliveEnemies.Clear();
        for (int i = 0; i < 4; i++)
        {
            if(enemyPositions[i].childCount > 0)
            {
                foreach (Transform child in enemyPositions[i])
                    Destroy(child.gameObject);
            }
            if(i < enemies.Count)
            {
                var enemy = Instantiate(enemies[i].combatPrefab, enemyPositions[i]);
                var enemyCombatCharacter = enemy.GetComponent<CombatCharacter>();
                enemyCombatCharacter.position = i+1;
                enemy.GetComponent<CombatStats>().SetupStats(enemies[i]);
                GetComponent<Turn>().aliveEnemies.Add(enemyCombatCharacter);
            }
        }
    }

    public void SpawnHeros()
    {
        GetComponent<Turn>().aliveHeroes.Clear();
        var heroes = GameManager.TeamManager.heroes;

        for (int i = 0; i < 4; i++)
        {
            if (heroPositions[i].childCount > 0)
            {
                foreach (Transform child in heroPositions[i])
                    Destroy(child.gameObject);
            }
            if (i < heroes.Count)
            {
                var heroData = heroes[i].GetComponent<Hero>().heroData;
                var hero = Instantiate(heroData.combatPrefab, heroPositions[i]);
                var heroCombatCharacter = hero.GetComponent<CombatCharacter>();
                heroCombatCharacter.position = i + 1;
                hero.GetComponent<CombatStats>().SetupStats(heroData);
                GetComponent<Turn>().aliveHeroes.Add(heroCombatCharacter);
                heroCombatCharacter.heroData = heroData;
                heroCombatCharacter.inventory = heroes[i].GetComponent<Inventory>();

                if (i == 0)
                    GameManager.CombatManager.currentCharacter = heroCombatCharacter;
            }
        }
    }
}