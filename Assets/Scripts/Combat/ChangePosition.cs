using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    public List<bool> enemyPositionOccupied;
    public List<bool> heroPositionOccupied;
    private void Awake()
    {
        enemyPositionOccupied = new List<bool> { false, false, false, false };
        heroPositionOccupied = new List<bool> { false, false, false, false };
    }

    public void OnEnemyDead()
    {
        for(int i = 1; i< 4; i++)
        {
            if (GameManager.CombatManager.LoadCharacters.enemyPositions[i].childCount == 0)
                continue;

            var enemy = GameManager.CombatManager.LoadCharacters.enemyPositions[i].transform.GetChild(0).gameObject;

            int goToPos = FindFirstEmptyPosition(false);
            print(i + " " + goToPos);
            if (goToPos >= i || goToPos == -1)
                continue;

            enemy.transform.parent = GameManager.CombatManager.LoadCharacters.enemyPositions[goToPos];
            enemy.GetComponent<CombatCharacter>().position = goToPos + 1;
            enemyPositionOccupied[goToPos] = true;
            enemyPositionOccupied[i] = false;
            StartCoroutine(SmoothChange(enemy));
            //enemy.transform.localPosition = Vector3.zero; 
        }
    }

    public int FindFirstEmptyPosition(bool hero)
    {
        if(!hero)
        {
            for (int i = 0; i < 4; i++)
            {
                if(!enemyPositionOccupied[i])
                {
                    return i;
                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (!heroPositionOccupied[i])
                {
                    return i;
                }
            }
        }

        return -1;
    }

    public void MoveBack(CombatCharacter combatCharacter)
    {
        var goToPos = 4;
        if (combatCharacter.isHero)
            return;

        if (enemyPositionOccupied[goToPos-1])
        {
            return;
        }

        combatCharacter.transform.parent = GameManager.CombatManager.LoadCharacters.enemyPositions[goToPos-1];
        enemyPositionOccupied[combatCharacter.position - 1] = false;
        combatCharacter.position = goToPos;
        enemyPositionOccupied[goToPos-1] = true;
        
        StartCoroutine(SmoothChange(combatCharacter.gameObject));
    }


    IEnumerator SmoothChange(GameObject character)
    {
        float time = 0.75f;
        float timer = 0;

        Vector3 startPos = character.transform.localPosition;

        while(timer < time)
        {
            timer += Time.deltaTime;
            character.transform.localPosition = Vector3.Lerp(startPos, Vector3.zero, timer / time);
            yield return null;
        }
    }
}
