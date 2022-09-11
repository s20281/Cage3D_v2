using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    public bool isEnabled;

    private void Start()
    {
        Switch(true);
        isEnabled = true;
    }

    public void Switch(bool on)
    {
        GetComponent<MeshRenderer>().enabled = on;
        isEnabled = on;
    }

}
