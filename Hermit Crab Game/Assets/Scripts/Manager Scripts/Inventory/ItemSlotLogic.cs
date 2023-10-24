using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotLogic : MonoBehaviour, IPointerClickHandler
{
    public bool selected = false;
    [SerializeField] private GameObject selectIndicator;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (!selected)
        {
            selected = true;
            selectIndicator.SetActive(true);
        }
        else
        {
            selected = false;
            selectIndicator.SetActive(false);
        }

    }
}
