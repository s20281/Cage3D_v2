using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel : MonoBehaviour
{
    [SerializeField] private List<int> enemiesIDs = new List<int>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (int)Layer.Player)
        {
            GameManager.CombatManager.StartCombat(enemiesIDs);

            Destroy(gameObject);
        }
    }


}
