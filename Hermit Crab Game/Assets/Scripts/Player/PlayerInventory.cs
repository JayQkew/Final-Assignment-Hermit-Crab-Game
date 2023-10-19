using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

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

    private void Update()
    {
        #region DEBUG BUTTON
        if (Input.GetKeyDown(KeyCode.P)) ClearInventory();

        if (Input.GetKeyDown(KeyCode.Alpha1)) Debug.Log(inventory.ingredientInventory[0][0]);
        if (Input.GetKeyDown(KeyCode.Alpha2)) Debug.Log(inventory.ingredientInventory[1][0]);
        if (Input.GetKeyDown(KeyCode.Alpha3)) Debug.Log(inventory.ingredientInventory[2][0]);
        if (Input.GetKeyDown(KeyCode.Alpha4)) Debug.Log(inventory.ingredientInventory[3][0]);
        if (Input.GetKeyDown(KeyCode.Alpha5)) Debug.Log(inventory.ingredientInventory[4][0]);
        if (Input.GetKeyDown(KeyCode.Alpha6)) Debug.Log(inventory.ingredientInventory[5][0]);
        if (Input.GetKeyDown(KeyCode.Alpha7)) Debug.Log(inventory.ingredientInventory[6][0]);
        if (Input.GetKeyDown(KeyCode.Alpha8)) Debug.Log(inventory.ingredientInventory[7][0]);
        if (Input.GetKeyDown(KeyCode.Alpha9)) Debug.Log(inventory.ingredientInventory[8][0]);
        if (Input.GetKeyDown(KeyCode.Alpha0)) Debug.Log(inventory.ingredientInventory[9][0]);

        if (Input.GetKeyDown(KeyCode.Keypad1)) Debug.Log(StackCount(inventory.ingredientInventory[0]));
        if (Input.GetKeyDown(KeyCode.Keypad2)) Debug.Log(StackCount(inventory.ingredientInventory[1]));
        if (Input.GetKeyDown(KeyCode.Keypad3)) Debug.Log(StackCount(inventory.ingredientInventory[2]));
        if (Input.GetKeyDown(KeyCode.Keypad4)) Debug.Log(StackCount(inventory.ingredientInventory[3]));
        if (Input.GetKeyDown(KeyCode.Keypad5)) Debug.Log(StackCount(inventory.ingredientInventory[4]));
        if (Input.GetKeyDown(KeyCode.Keypad6)) Debug.Log(StackCount(inventory.ingredientInventory[5]));
        if (Input.GetKeyDown(KeyCode.Keypad7)) Debug.Log(StackCount(inventory.ingredientInventory[6]));
        if (Input.GetKeyDown(KeyCode.Keypad8)) Debug.Log(StackCount(inventory.ingredientInventory[7]));
        if (Input.GetKeyDown(KeyCode.Keypad9)) Debug.Log(StackCount(inventory.ingredientInventory[8]));
        if (Input.GetKeyDown(KeyCode.Keypad0)) Debug.Log(StackCount(inventory.ingredientInventory[9]));



        #endregion
    }

    public void SortIngredient(GameObject ingredient)
    {
        IngredientType type = ingredient.GetComponent<IngredientLogic>().ingredient;

        for (int i = 0; i < inventory.ingredientInventory.Count; i++)
        {
            // check if that slot is free
            if (inventory.ingredientInventory[i][0] == IngredientType.Empty)
            {
                inventory.ingredientInventory[i][0] = type;
                break;
            }

            else if (inventory.ingredientInventory[i][0] == type)
            {
                for (int j = 0; j < inventory.stackSize; j++)
                {
                    if (inventory.ingredientInventory[i][j] == IngredientType.Empty)
                    {
                        inventory.ingredientInventory[i][j] = type;
                        break;
                    }
                }
                break;
            }
        }
    }

    private int StackCount(IngredientType[] itemSlot)
    {
        int stackCount = 0;

        if (itemSlot[0] != IngredientType.Empty)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i] != IngredientType.Empty) stackCount++;
            }
        }

        return stackCount;
    }

    private void ClearInventory()
    {
        for (int i = 0; i < inventory.ingredientInventory.Count; i++)
        {
            for (int j = 0; j < inventory.ingredientInventory[i].Length; j++)
            {
                inventory.ingredientInventory[i][j] = IngredientType.Empty;
            }
        }
    }
}
