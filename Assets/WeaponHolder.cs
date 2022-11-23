using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> weapons = new List<GameObject>();


    public void SwitchWeapons(int id)
    {
        for(int i = 0; i< weapons.Count; i++)
        {
            weapons[i].SetActive(id == i);
        }
    }

}
