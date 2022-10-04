using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Read/ReadObject")]
public class ReadObject : ScriptableObject
{
    [SerializeField] [TextArea] private string readText;

    public string Read => readText;

}
