using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public SO_Map locations;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial 4")
        {
            IngredientsCheck();
        }
    }

    private void IngredientsCheck()
    {
        if (PlayerInventory.Instance.inventory.ingredientInventory[2][0] != IngredientType.Empty)
        {
            LoadTut5();
        }
    }

    private void LoadTut5()
    {
        SceneManager.LoadScene("Tutorial 5");
    }

}
