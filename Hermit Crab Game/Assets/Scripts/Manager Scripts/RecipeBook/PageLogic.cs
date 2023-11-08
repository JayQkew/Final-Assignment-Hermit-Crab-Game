using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageLogic : MonoBehaviour
{
    public Recipes recipe;

    [SerializeField] private GameObject[] p_recipes;
    [SerializeField] private GameObject[] p_ingredients;

    public bool pageSet = false;
    public bool pageActive;
    public int pageIndex = 0;

    public Image recipeSprite;

    public GameObject p_requirements;
    public Transform requirmentParent;
    [SerializeField] private TextMeshProUGUI recipeName;

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
}
