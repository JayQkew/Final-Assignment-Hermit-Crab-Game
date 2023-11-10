using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecipeBookButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static RecipeBookButton Instance { get; private set; }
    public GameObject recipeBookPanel;

    private void Awake()
    {
        Instance = this;
    }
    public void OpenRecipeBook()
    {
        recipeBookPanel.SetActive(true);
        gameObject.SetActive(false);

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OpenRecipeBook();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
