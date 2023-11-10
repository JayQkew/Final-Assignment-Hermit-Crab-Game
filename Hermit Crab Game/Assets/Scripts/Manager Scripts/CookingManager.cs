using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookingManager : MonoBehaviour
{
    public static CookingManager Instance { get; private set; }

    [SerializeField] private GameObject button;
    public void CookButton()
    {
        switch (RecipeBookManager.Instance.activePage.GetComponent<PageLogic>().recipe)
        {
            case Recipes.None:
                break;
            case Recipes.OumasPotjieKos:
                PlayerInventory.Instance.CookedDish(Dishes.OumasPotjieKos);
                break;
            case Recipes.BraaiKos:
                PlayerInventory.Instance.CookedDish(Dishes.BraaiKos);
                break;
            case Recipes.PapNKos:
                PlayerInventory.Instance.CookedDish(Dishes.PapNWors);
                break;
            case Recipes.BunnyChow:
                PlayerInventory.Instance.CookedDish(Dishes.BunnyChow);
                break;
            case Recipes.Vetkoek:
                PlayerInventory.Instance.CookedDish(Dishes.Vetkoek);
                break;
            case Recipes.Kota:
                PlayerInventory.Instance.CookedDish(Dishes.Kota);
                break;
            case Recipes.RoosterkoekChips:
                PlayerInventory.Instance.CookedDish(Dishes.RoosterkoekChips);
                break;
            case Recipes.YourPotjieOne:
                PlayerInventory.Instance.CookedDish(Dishes.YourPotjieOne);
                break;
            case Recipes.YourPotjieTwo:
                PlayerInventory.Instance.CookedDish(Dishes.YourPotjieTwo);
                break;
        }
        RecipeBookManager.Instance.activePage.GetComponent<PageLogic>().UseIngredients();
        UIManager.Instance.recipeBookButton.SetActive(true);
        UIManager.Instance.recipeBookUI.SetActive(false);
        button.SetActive(false);
        
    }
}

