using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TeamSlot : MonoBehaviour, IDropHandler
{
    public DragHeroes dragHeroes;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            print(eventData.pointerDrag.name);
            eventData.pointerClick.GetComponent<DragHeroes>();
        }
    }
}
