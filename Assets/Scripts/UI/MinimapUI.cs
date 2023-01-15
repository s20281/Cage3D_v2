using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUI: MonoBehaviour
{
    [SerializeField] private GameObject minimap;
    private bool isMapTogglingBlocked = false;
    private bool wasActive = true;

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
        if (GameManager.UIManager.inventoryUI.inventoryPanel.activeSelf && GameManager.UIManager.readUI.gameObject.activeSelf)
        {
            Debug.Log("Dwa otwarte");
        }
        else
        {
           wasActive = minimap.activeSelf;
        }
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
