using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUI: MonoBehaviour
{
    [SerializeField] private GameObject minimap;
    private bool isMapTogglingBlocked;
    private bool wasActive;

    void Start()
    {
        isMapTogglingBlocked = false;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMinimap();
        }

    }

    public void turnOffMinimap()
    {
        wasActive = minimap.activeSelf;
        minimap.SetActive(false);
        isMapTogglingBlocked = true;
    }

    public void turnOnMinimap()
    {
        minimap.SetActive(wasActive);
        isMapTogglingBlocked = false;
    }



    public void ToggleMinimap()
    {
        if (!isMapTogglingBlocked)
        {
            minimap.SetActive(!minimap.activeSelf);
        }

    }
}
