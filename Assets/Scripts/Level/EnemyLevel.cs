using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel : MonoBehaviour
{
    //[SerializeField] private List<int> enemiesIDs = new List<int>();
    [SerializeField] private List<EnemyData> enemies = new List<EnemyData>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (int)Layer.Player)
        {
            GameManager.CombatManager.StartCombat(enemies);

            Destroy(gameObject);
        }
    }


}
