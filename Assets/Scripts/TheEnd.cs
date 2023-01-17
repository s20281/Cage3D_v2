using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TheEnd : MonoBehaviour
{
    public TMP_Text textLabel;
    public GameObject readStoryPanel;
    public ReadObject end1GoodOrStart;
    public ReadObject end2SoSo;
    public ReadObject end3TheWorst;
    public bool isStart;
    public bool wasOpened = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (!wasOpened)
        {
            readStoryPanel.SetActive(true);

            if (isStart)
            {
                if (textLabel != null)
                {
                    textLabel.text = end1GoodOrStart.Read;
                }
                wasOpened = true;
            }
            else
            {

                GameManager.UIManager.minimapUI.turnOffMinimap();

                if (textLabel != null)
                {
                    gameObject.SetActive(true);

                    if (end1GoodOrStart != null && GameManager.PlayerManager.GetMindPoints() > 20)
                    {
                        textLabel.text = end1GoodOrStart.Read;
                    }
                    else
                    {
                        if (end3TheWorst != null && GameManager.PlayerManager.GetMindPoints() < -20)
                        {
                            textLabel.text = end3TheWorst.Read;
                        }
                        else
                        {
                            if (end2SoSo != null && GameManager.PlayerManager.GetMindPoints() > -20 && GameManager.PlayerManager.GetMindPoints() < 20)
                            {
                                textLabel.text = end2SoSo.Read;
                            }
                        }
                    }
                }
            }
        }
    }

    void Update()
    {
        if (readStoryPanel.active && Input.GetKeyDown(KeyCode.Space) && isStart)
        {
            readStoryPanel.SetActive(false);
        }
    }
}
