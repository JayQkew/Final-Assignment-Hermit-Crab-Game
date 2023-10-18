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

    #region Ingredient Prefabs
    [SerializeField] private GameObject Tomato;
    [SerializeField] private GameObject Onion;
    [SerializeField] private GameObject Mushrooms;
    [SerializeField] private GameObject Potato;
    [SerializeField] private GameObject Herbs;
    [SerializeField] private GameObject Mielies;
    [SerializeField] private GameObject Carrots;
    [SerializeField] private GameObject Beans;
    [SerializeField] private GameObject Garlic;
    [SerializeField] private GameObject Chillies;
    #endregion 

    #region Temporary Inventory
    [Header("Inventory")]
    private GameObject[] slot1 = new GameObject[5];
    private GameObject[] slot2 = new GameObject[5];
    private GameObject[] slot3 = new GameObject[5];
    private GameObject[] slot4 = new GameObject[5];
    private GameObject[] slot5 = new GameObject[5];
    private GameObject[] slot6 = new GameObject[5];
    private GameObject[] slot7 = new GameObject[5];
    private GameObject[] slot8 = new GameObject[5];
    private GameObject[] slot9 = new GameObject[5];
    private GameObject[] slot10 = new GameObject[5];

    [SerializeField] private List<GameObject[]> ingredientInventory = new List<GameObject[]>();
    #endregion

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

        #region Add Arrays to TempInv
        ingredientInventory.Add(slot1);
        ingredientInventory.Add(slot2);
        ingredientInventory.Add(slot3);
        ingredientInventory.Add(slot4);
        ingredientInventory.Add(slot5);
        ingredientInventory.Add(slot6);
        ingredientInventory.Add(slot7);
        ingredientInventory.Add(slot8);
        ingredientInventory.Add(slot9);
        ingredientInventory.Add(slot10);
        #endregion

        SyncTempInventory();
    }

    private void Update()
    {
        #region DEBUG BUTTON
        if (Input.GetKeyDown(KeyCode.P))
        {
            SyncPermInventory();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) Debug.Log(ingredientInventory[0][0]);
        if (Input.GetKeyDown(KeyCode.Alpha2)) Debug.Log(ingredientInventory[1][0]);
        if (Input.GetKeyDown(KeyCode.Alpha3)) Debug.Log(ingredientInventory[2][0]);
        if (Input.GetKeyDown(KeyCode.Alpha4)) Debug.Log(ingredientInventory[3][0]);
        if (Input.GetKeyDown(KeyCode.Alpha5)) Debug.Log(ingredientInventory[4][0]);
        if (Input.GetKeyDown(KeyCode.Alpha6)) Debug.Log(ingredientInventory[5][0]);
        if (Input.GetKeyDown(KeyCode.Alpha7)) Debug.Log(ingredientInventory[6][0]);
        if (Input.GetKeyDown(KeyCode.Alpha8)) Debug.Log(ingredientInventory[7][0]);
        if (Input.GetKeyDown(KeyCode.Alpha9)) Debug.Log(ingredientInventory[8][0]);
        if (Input.GetKeyDown(KeyCode.Alpha0)) Debug.Log(ingredientInventory[9][0]);

        if (Input.GetKeyDown(KeyCode.Keypad1)) Debug.Log(StackCount(ingredientInventory[0]));
        if (Input.GetKeyDown(KeyCode.Keypad2)) Debug.Log(StackCount(ingredientInventory[1]));
        if (Input.GetKeyDown(KeyCode.Keypad3)) Debug.Log(StackCount(ingredientInventory[2]));
        if (Input.GetKeyDown(KeyCode.Keypad4)) Debug.Log(StackCount(ingredientInventory[3]));
        if (Input.GetKeyDown(KeyCode.Keypad5)) Debug.Log(StackCount(ingredientInventory[4]));
        if (Input.GetKeyDown(KeyCode.Keypad6)) Debug.Log(StackCount(ingredientInventory[5]));
        if (Input.GetKeyDown(KeyCode.Keypad7)) Debug.Log(StackCount(ingredientInventory[6]));
        if (Input.GetKeyDown(KeyCode.Keypad8)) Debug.Log(StackCount(ingredientInventory[7]));
        if (Input.GetKeyDown(KeyCode.Keypad9)) Debug.Log(StackCount(ingredientInventory[8]));
        if (Input.GetKeyDown(KeyCode.Keypad0)) Debug.Log(StackCount(ingredientInventory[9]));



        #endregion
    }

    private void SyncTempInventory()
    {
        slot1 = PrefabToGameObject(inventory.slot1);
        slot2 = PrefabToGameObject(inventory.slot2);
        slot3 = PrefabToGameObject(inventory.slot3);
        slot4 = PrefabToGameObject(inventory.slot4);
        slot5 = PrefabToGameObject(inventory.slot5);
        slot6 = PrefabToGameObject(inventory.slot6);
        slot7 = PrefabToGameObject(inventory.slot7);
        slot8 = PrefabToGameObject(inventory.slot8);
        slot9 = PrefabToGameObject(inventory.slot9);
        slot10 = PrefabToGameObject(inventory.slot10);
    }

    private void SyncPermInventory()
    {
        inventory.slot1 = GameObjectToPrefab(slot1);
        inventory.slot2 = GameObjectToPrefab(slot2);
        inventory.slot3 = GameObjectToPrefab(slot3);
        inventory.slot4 = GameObjectToPrefab(slot4);
        inventory.slot5 = GameObjectToPrefab(slot5);
        inventory.slot6 = GameObjectToPrefab(slot6);
        inventory.slot7 = GameObjectToPrefab(slot7);
        inventory.slot8 = GameObjectToPrefab(slot8);
        inventory.slot9 = GameObjectToPrefab(slot9);
        inventory.slot10 = GameObjectToPrefab(slot10);
        Debug.Log("Synced");
    }

    public void SortIngredient(GameObject ingredient)
    {
        for (int i = 0; i < ingredientInventory.Count; i++)
        {
            // check if that slot is free
            if (ingredientInventory[i][0] == null)
            {
                ingredientInventory[i][0] = ingredient;
                break;
            }

            else if (ingredientInventory[i][0].GetComponent<IngredientLogic>().ingredient == ingredient.GetComponent<IngredientLogic>().ingredient )
            {
                for (int j = 0; j < inventory.stackSize; j++)
                {
                    if (ingredientInventory[i][j] == null)
                    {
                        ingredientInventory[i][j] = ingredient;
                        break;
                    }
                }
                break;
            }
        }
    }

    private GameObject[] GameObjectToPrefab(GameObject[] slot) // converts gameObject_array to enum_array
    {
        GameObject[] prefabArray = new GameObject[slot.Length];

        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i] != null) prefabArray[i] = slot[i];
            else prefabArray[i] = null;
        }

        return prefabArray;
    }

    private GameObject[] PrefabToGameObject(GameObject[] slot) // converts enum_array to gameObjecy_array
    {
        GameObject[] gameObjectArray = new GameObject[slot.Length];

        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i] == null) gameObjectArray[i] = null;
            else
            {
                gameObjectArray[i] = PrefabMatch(slot[i]);
            }
        }

        return gameObjectArray;
    }

    private GameObject PrefabMatch(GameObject ingredient)
    {
        GameObject _ingredient = null;

        switch (ingredient.GetComponent<IngredientLogic>().ingredient)
        {
            case IngredientType.Empty:
                _ingredient = null;
                break;
            case IngredientType.Tomato:
                _ingredient = Tomato;
                break;
            case IngredientType.Onion:
                _ingredient = Onion;
                break;
            case IngredientType.Mushrooms:
                _ingredient = Mushrooms;
                break;
            case IngredientType.Potato:
                _ingredient = Potato;
                break;
            case IngredientType.Herbs:
                _ingredient = Herbs;
                break;
            case IngredientType.Mielies:
                _ingredient = Mielies;
                break;
            case IngredientType.Carrots:
                _ingredient = Carrots;
                break;
            case IngredientType.Beans:
                _ingredient = Beans;
                break;
            case IngredientType.Garlic:
                _ingredient = Garlic;
                break;
            case IngredientType.Chillies:
                _ingredient = Chillies;
                break;
            case IngredientType.Meat:
                break;
            case IngredientType.Vors:
                break;
            case IngredientType.Chicken:
                break;
            case IngredientType.Fish:
                break;
            case IngredientType.Spices:
                break;
            case IngredientType.MielieMeal:
                break;
            case IngredientType.Oil:
                break;
            case IngredientType.Butter:
                break;
            case IngredientType.Bread:
                break;
            case IngredientType.Chakalaka:
                break;
            case IngredientType.Atchaar:
                break;
            case IngredientType.Flour:
                break;
            case IngredientType.Sugar:
                break;
        }

        return _ingredient;
    }

    private int StackCount(GameObject[] itemSlot)
    {
        int stackCount = 0;

        if (itemSlot[0] != null)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i] != null) stackCount++;
            }
        }

        return stackCount;
    }
}
