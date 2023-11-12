using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PageLogic : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public Recipes recipe;


    public bool selected = false;
    [SerializeField] private GameObject cookButton;
    [SerializeField] private GameObject selectedIcon;
    [SerializeField] private GameObject[] p_recipes;
    [SerializeField] private GameObject[] p_ingredients;

    [SerializeField] private GameObject pageRecipe = null;

    public bool pageSet = false;
    public bool pageActive;
    public int pageIndex = 0;

    public Image recipeSprite;

    public GameObject p_requirements;
    public Transform requirmentParent;
    [SerializeField] private TextMeshProUGUI recipeName;

    [SerializeField] private Color startColour;
    [SerializeField] private Color hoverColourCan;
    [SerializeField] private Color hoverColourCant;


    private void Start()
    {
        cookButton = GameObject.FindGameObjectWithTag("cookButton");
        startColour = GetComponent<Image>().color;
    }

    private void Update()
    {

            if (selected) cookButton.transform.GetChild(0).gameObject.SetActive(true);
            else cookButton.transform.GetChild(0).gameObject.SetActive(false);


        SetPage();

    }

    public void SetPage()
    {
        if (recipe != Recipes.None && !pageSet)
        {
            foreach (GameObject _recipe in p_recipes) //loop through each prefab
            {
                if (_recipe.GetComponent<RecipeLogic>().recipe == recipe) //if prefab matches recipe enum
                {
                    RequirementSpawn(_recipe.GetComponent<RecipeLogic>().recipeBase.ingredientsNeeded, _recipe);
                    recipeName.text = _recipe.GetComponent<RecipeLogic>().recipeBase.recipeName.Trim();
                    recipeSprite.sprite = _recipe.GetComponent<RecipeLogic>().dish.GetComponent<SpriteRenderer>().sprite;
                    recipeSprite.color = _recipe.GetComponent<RecipeLogic>().dish.GetComponent<SpriteRenderer>().color;
                    pageSet = true;
                    pageRecipe = _recipe;
                    break;
                }
            }
        }
    }

    private void RequirementSpawn(IngredientType[] ingredients, GameObject _recipe)
    {
        List<GameObject> selectedIngredients = new List<GameObject>();

        foreach (IngredientType ingredient in ingredients)
        {
            foreach (GameObject _ingredient in p_ingredients)
            {
                if (_ingredient.GetComponent<IngredientLogic>().ingredient == ingredient)
                {
                    selectedIngredients.Add(_ingredient);
                }
            }
        }

        for (int i = 0; i < ingredients.Length; i++)
        {
            GameObject _requirementSlot = Instantiate(p_requirements, requirmentParent); //spawn a prefab under the parent

            _requirementSlot.GetComponentInChildren<TextMeshProUGUI>().text = _recipe.GetComponent<RecipeLogic>().recipeBase.amountRequired[i].ToString();
            _requirementSlot.GetComponentInChildren<Image>().sprite = selectedIngredients[i].GetComponent<SpriteRenderer>().sprite;
            _requirementSlot.GetComponentInChildren<Image>().color = selectedIngredients[i].GetComponent<SpriteRenderer>().color;
        }
    }

    public void ActiveCheck()
    {
        if (pageActive)
        {
            GameObject pageParent = transform.parent.gameObject;
            transform.SetSiblingIndex(pageParent.transform.childCount - 1);
        }
    }

    private bool CanMakeRecipe()
    {
        RecipeBase _recipe = pageRecipe.GetComponent<RecipeLogic>().recipeBase;
        bool[] hasEnoughIngredients = new bool[_recipe.ingredientsNeeded.Length];

        for (int i = 0; i < _recipe.ingredientsNeeded.Length; i++)
        {
            if (PlayerInventory.Instance.IngredientsAmountCheck(_recipe.ingredientsNeeded[i], _recipe.amountRequired[i])) hasEnoughIngredients[i] = true;
            else
            {
                Debug.Log("Doenst have enough " + _recipe.ingredientsNeeded[i]);
                return false;
            }
        }
        foreach (bool enoughIngredient in hasEnoughIngredients)
        {
            if (enoughIngredient == false) return false;
        }

        return true;
    }

    public void UseIngredients()
    {
        RecipeBase _recipe = pageRecipe.GetComponent<RecipeLogic>().recipeBase;

        for (int i = 0; i < _recipe.ingredientsNeeded.Length; i++)
        {
            PlayerInventory.Instance.GiveIngredients(_recipe.ingredientsNeeded[i], _recipe.amountRequired[i]);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SceneManager.GetActiveScene().name == "House" && pageRecipe != null)
        {
            if (CanMakeRecipe() && PlayerInventory.Instance.inventory.dish == Dishes.None)
            {
                if (selected)
                {
                    selected = false;
                    RecipeBookManager.Instance.activePage = null;
                }
                else
                {
                    selected = true;
                    RecipeBookManager.Instance.activePage = gameObject;
                }
            }
            else GetComponent<Image>().color = Color.red;
        }
        else if (SceneManager.GetActiveScene().name == "Tutorial 5" && pageRecipe != null)
        {
            if (CanMakeRecipe() && PlayerInventory.Instance.inventory.dish == Dishes.None)
            {
                if (selected)
                {
                    selected = false;
                    RecipeBookManager.Instance.activePage = null;
                }
                else
                {
                    selected = true;
                    RecipeBookManager.Instance.activePage = gameObject;
                }
            }
            else GetComponent<Image>().color = Color.red;
        }

        selectedIcon.SetActive(selected);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (SceneManager.GetActiveScene().name == "House" && pageRecipe != null)
        {
            if (CanMakeRecipe() && PlayerInventory.Instance.inventory.dish == Dishes.None) GetComponent<Image>().color = hoverColourCan;
            else GetComponent<Image>().color = hoverColourCant;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (SceneManager.GetActiveScene().name == "House" && pageRecipe != null)
        {
            GetComponent<Image>().color = startColour;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().color = startColour;
    }
}
