using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUI: MonoBehaviour
{
    [SerializeField] private GameObject minimap;
    private bool isMapTogglingBlocked;

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
       /* if (miniMap.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            //zmniejsz
        }*/


    }

    public void ToggleMinimap()
    {
       /* if (!isMapTogglingBlocked)
        {
            minimap.SetActive(!minimap.activeSelf);
        }*/

    }

    public void blockUnblockMapToggling()
    {
        isMapTogglingBlocked = !isMapTogglingBlocked;

    }

  /*  //w przyszlosci mo¿e
    void makeMapBigger()
    {
        if (!isHidden)
        {
            //zwiekszMape
            //zatrzymajgre
        }

    }
    void makeSmallerMap()
    {
        if (!isHidden)
        {
            //zmniejszMape
            //puscgre
        }
    }*/
}
