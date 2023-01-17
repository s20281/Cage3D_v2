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
            dragHeroes = eventData.pointerDrag.GetComponent<DragHeroes>();

            dragHeroes.currentSlot = this;
        }
    }

    public void PutHero(DragHeroes dragHeroes)
    {
        this.dragHeroes = dragHeroes;
        dragHeroes.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        dragHeroes.currentSlot = this;
    }

}
