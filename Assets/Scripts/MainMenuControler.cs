using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{
    [SerializeField] GameObject mainMenuGO;
    [SerializeField] GameObject creditsGO;
    [SerializeField] GameObject controlsGO;

    [SerializeField] GameObject startGO;
    [SerializeField] GameObject continueGO;

    [SerializeField] Image backgroundImage;

    private void Start()
    {
        SwitchMenu(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenuGO.activeSelf)
                SwitchMenu(false);
            else if(!GameManager.UIManager.inventoryUI.inventoryPanel.activeSelf)
            {
                SwitchMenu(true);
            }
        }   
    }

    public void StartGame()
    {
        //SceneManager.LoadScene(1);
        SwitchMenu(false);

        backgroundImage.color = new Color32(0, 0, 0, 200);
        startGO.SetActive(false);
        continueGO.SetActive(true);


        print("startGame");
    }

    public void Controls()
    {
        creditsGO.SetActive(false);
        controlsGO.SetActive(!controlsGO.activeSelf);
    }

    public void Credits()
    {
        controlsGO.SetActive(false);
        creditsGO.SetActive(!creditsGO.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SwitchMenu(bool active)
    {
        mainMenuGO.SetActive(active);
        GameManager.PlayerManager.playerMovement.SwitchFreeze(active);

        controlsGO.SetActive(false);
        creditsGO.SetActive(false);
    }


}
