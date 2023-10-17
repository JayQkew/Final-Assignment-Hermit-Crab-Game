using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public SO_Inventory inventory;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        #region Add Arrays to ScriptableObject
        inventory.ingredientInventory.Add(inventory.slot1);
        inventory.ingredientInventory.Add(inventory.slot2);
        inventory.ingredientInventory.Add(inventory.slot3);
        inventory.ingredientInventory.Add(inventory.slot4);
        inventory.ingredientInventory.Add(inventory.slot5);
        inventory.ingredientInventory.Add(inventory.slot6);
        inventory.ingredientInventory.Add(inventory.slot7);
        inventory.ingredientInventory.Add(inventory.slot8);
        inventory.ingredientInventory.Add(inventory.slot9);
        inventory.ingredientInventory.Add(inventory.slot10);
        #endregion
    }

    public void SortIngredient(GameObject ingredient)
    {
        for (int i = 0; i < inventory.ingredientInventory.Count; i++)
        {
            // check if that slot is free
            if (inventory.ingredientInventory[i][0] == IngredientType.Empty)
            {
                inventory.ingredientInventory[i][0] = ingredient.GetComponent<IngredientLogic>().ingredient;
                break;
            }

            else if (inventory.ingredientInventory[i][0] == ingredient.GetComponent<IngredientLogic>().ingredient)
            {
                for (int j = 0; j < inventory.stackSize; j++)
                {
                    if (inventory.ingredientInventory[i][j] == IngredientType.Empty)
                    {
                        inventory.ingredientInventory[i][j] = ingredient.GetComponent<IngredientLogic>().ingredient;
                        break;

                    }
                }
                break;
            }
        }
    }

    /*
     *         int dimension_1 = 0;
        int dimension_2 = 0;

        for (int i = 0; i < inventory.ingredientInventory.GetLength(0); i++)
        {
            if (inventory.ingredientInventory[i, 0] == null) // if there is an empty space in 2D array
            {
                dimension_1 = i;
                dimension_2 = 0;
                break;
            }
            else if (inventory.ingredientInventory[i, 0].GetComponent<IngredientLogic>().ingredient == ingredient.GetComponent<IngredientLogic>().ingredient) // if same type of ingredient
            {
                for (int j = 0; j < inventory.ingredientInventory.GetLength(1); j++)
                {
                    if (inventory.ingredientInventory[i, j] == null)
                    {
                        dimension_1 = i;
                        dimension_2 = j;
                        break;
                    }
                }
            }
        }

        Debug.Log(dimension_1 + " , " + dimension_2);

        inventory.ingredientInventory[dimension_1, dimension_2] = ingredient;

*/
}
