using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class TradeButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI amount;
    public GameObject forage;
    public GameObject trade;

    public int _amount;
    public IngredientType forageType;
    public IngredientType tradeType;

    private Color startColour;

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerInventory.Instance.Trade(forageType, _amount, trade);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        startColour = gameObject.GetComponent<Image>().color;

        if (!PlayerInventory.Instance.TradeCheck(forageType, _amount))
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.green;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = startColour;
    }
}
