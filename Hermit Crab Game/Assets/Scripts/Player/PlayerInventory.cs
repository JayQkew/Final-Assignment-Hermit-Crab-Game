using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

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
        #endregion
    }

    private void SyncTempInventory()
    {
        slot1 = EnumToGameObject(inventory.slot1);
        slot2 = EnumToGameObject(inventory.slot2);
        slot3 = EnumToGameObject(inventory.slot3);
        slot4 = EnumToGameObject(inventory.slot4);
        slot5 = EnumToGameObject(inventory.slot5);
        slot6 = EnumToGameObject(inventory.slot6);
        slot7 = EnumToGameObject(inventory.slot7);
        slot8 = EnumToGameObject(inventory.slot8);
        slot9 = EnumToGameObject(inventory.slot9);
        slot10 = EnumToGameObject(inventory.slot10);
    }

    private void SyncPermInventory()
    {
        inventory.slot1 = GameObjectToEnum(slot1);
        inventory.slot2 = GameObjectToEnum(slot2);
        inventory.slot3 = GameObjectToEnum(slot3);
        inventory.slot4 = GameObjectToEnum(slot4);
        inventory.slot5 = GameObjectToEnum(slot5);
        inventory.slot6 = GameObjectToEnum(slot6);
        inventory.slot7 = GameObjectToEnum(slot7);
        inventory.slot8 = GameObjectToEnum(slot8);
        inventory.slot9 = GameObjectToEnum(slot9);
        inventory.slot10 = GameObjectToEnum(slot10);
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

            else if (ingredientInventory[i][0] == ingredient)
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

    private IngredientType[] GameObjectToEnum(GameObject[] slot) // converts gameObject_array to enum_array
    {
        IngredientType[] enumArray = new IngredientType[slot.Length];

        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i] != null) enumArray[i] = slot[i].GetComponent<IngredientLogic>().ingredient;
            else enumArray[i] = IngredientType.Empty;
        }

        return enumArray;
    }

    private GameObject[] EnumToGameObject(IngredientType[] slot) // converts enum_array to gameObjecy_array
    {
        GameObject[] gameObjectArray = new GameObject[slot.Length];

        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i] == IngredientType.Empty) gameObjectArray[i] = null;
            else
            {
                gameObjectArray[i] = PrefabMatch(slot[i]);
            }
        }

        return gameObjectArray;
    }

    private GameObject PrefabMatch(IngredientType ingredient)
    {
        GameObject _ingredient = null;

        switch (ingredient)
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

}
