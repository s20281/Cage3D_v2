using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private DialogueUI dialogueUI;
    private List<GameObject> tempResponseButtons = new List<GameObject>();

    void Start()
    {
        responseBox.gameObject.SetActive(false);
        dialogueUI = GetComponent<DialogueUI>();
    }
    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0;

        foreach (Response response in responses)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickResponse(response));

            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y + 10;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }


    private void OnPickResponse(Response response)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons)
        {
            Destroy(button);

        }

        tempResponseButtons.Clear();

        if (response.ObjectToGive != null)
        {
            GameManager.TeamManager.tryRemoveItem(response.ObjectToGive);
        }

        if (response.ImpactOnMind != 0)
        {
            GameManager.PlayerManager.ChangeMindPoints(response.ImpactOnMind);
        }



        dialogueUI.ShowDialogue(response.DialogueObject, response.ObjectToGet, null, response.HeroToAdd, true, null, null);


    }




}
