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

        if (Input.GetKeyDown(KeyCode.Alpha1)) Debug.Log(inventory.ingredientInventory[0][0] + " " + StackCount(inventory.ingredientInventory[0]));
        if (Input.GetKeyDown(KeyCode.Alpha2)) Debug.Log(inventory.ingredientInventory[1][0] + " " + StackCount(inventory.ingredientInventory[1]));
        if (Input.GetKeyDown(KeyCode.Alpha3)) Debug.Log(inventory.ingredientInventory[2][0] + " " + StackCount(inventory.ingredientInventory[2]));
        if (Input.GetKeyDown(KeyCode.Alpha4)) Debug.Log(inventory.ingredientInventory[3][0] + " " + StackCount(inventory.ingredientInventory[3]));
        if (Input.GetKeyDown(KeyCode.Alpha5)) Debug.Log(inventory.ingredientInventory[4][0] + " " + StackCount(inventory.ingredientInventory[4]));
        if (Input.GetKeyDown(KeyCode.Alpha6)) Debug.Log(inventory.ingredientInventory[5][0] + " " + StackCount(inventory.ingredientInventory[5]));
        if (Input.GetKeyDown(KeyCode.Alpha7)) Debug.Log(inventory.ingredientInventory[6][0] + " " + StackCount(inventory.ingredientInventory[6]));
        if (Input.GetKeyDown(KeyCode.Alpha8)) Debug.Log(inventory.ingredientInventory[7][0] + " " + StackCount(inventory.ingredientInventory[7]));
        if (Input.GetKeyDown(KeyCode.Alpha9)) Debug.Log(inventory.ingredientInventory[8][0] + " " + StackCount(inventory.ingredientInventory[8]));
        if (Input.GetKeyDown(KeyCode.Alpha0)) Debug.Log(inventory.ingredientInventory[9][0] + " " + StackCount(inventory.ingredientInventory[9]));
        #endregion
    }

    public void SortIngredient(GameObject ingredient)
    {
        IngredientType type = ingredient.GetComponent<IngredientLogic>().ingredient;

        for (int i = 0; i < inventory.ingredientInventory.Count; i++)
        {
            // check if first slot is free
            if (inventory.ingredientInventory[i][0] == IngredientType.Empty)
            {
                inventory.ingredientInventory[i][0] = type;
                break;
            }

            else if (inventory.ingredientInventory[i][0] == type && !FullSlotCheck(inventory.ingredientInventory[i]))
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

    private bool FullSlotCheck(IngredientType[] slot)
    {
        if (StackCount(slot) == 5) return true;
        else return false;
    }

    public int StackCount(IngredientType[] itemSlot)
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

    public bool FullInventoryCheck()
    {
        int fullSlotCount = 0;

        foreach (IngredientType[] slot in inventory.ingredientInventory)
        {
            if (slot[0] != IngredientType.Empty) fullSlotCount++;
        }

        if (fullSlotCount != 10) return false;
        else return true;
    }

    public bool SpaceForIngredientCheck(IngredientType ingredient)
    {
        bool spaceAvailable = false;

        foreach (IngredientType[] slot in inventory.ingredientInventory)
        {
            if (slot[0] == ingredient && StackCount(slot) != 5)
            {
                spaceAvailable = true;
                break;
            }
            else
            {
                spaceAvailable = false;
            }
        }

        return spaceAvailable;
    }

    private int IngredientCount(IngredientType ingredient)
    {
        int netIngredients = 0;
        foreach (IngredientType[] slot in inventory.ingredientInventory)
        {
            if (slot[0] == ingredient) netIngredients += StackCount(slot);
        }

        return netIngredients;
    }

    private void GiveIngredients(IngredientType ingredient, int amount)
    {
        int ingredientsGiven = 0;

        foreach (IngredientType[] slot in inventory.ingredientInventory)
        {
            if (slot[0] == ingredient)
            {
                for (int i = StackCount(slot); i >= 0; i--)
                {
                    if (ingredientsGiven != amount)
                    {
                        slot[i - 1] = IngredientType.Empty;
                        ingredientsGiven++;
                    }
                }
            }
        }
    }

    public bool TradeCheck(IngredientType forage, int amount)
    {
        bool canTrade = false;

        foreach (IngredientType[] slot in inventory.ingredientInventory)
        {
            if (slot[0] == forage && IngredientCount(slot[0]) >= amount && !FullInventoryCheck())
            {
                canTrade = true;
                break;
            }
            else canTrade = false;
        }

        return canTrade;
    }

    public void Trade(IngredientType forage, int amount, GameObject trade)
    {
        if (TradeCheck(forage, amount) && !FullInventoryCheck() && IngredientCount(forage) >= amount)
        {
            GiveIngredients(forage, amount); // take away from inventory
            SortIngredient(trade);
            switch (NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcBase.npcName)
            {
                case NPCName.Monkey:
                case NPCName.Meerkat:
                case NPCName.Ostrich:
                    if ((NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcData.interactionPoints == 1 &&
                        !NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcData.givenRecipe) ||
                        (NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcData.interactionPoints == 4 &&
                        !NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcData.givenRecipe))
                    {
                        GameObject activeNPC = NPCActionLogic.Instance.activeNPC;
                        NPCActionLogic.Instance.NPCChange(NPCActions.Converse, 3);
                        RecieveRecipe(activeNPC.GetComponent<NPCLogic>().npcRecipe);
                        NPCActionLogic.Instance.OpenActiveAction();
                        DialogueManager.Instance.EnterDialogueMode(activeNPC.GetComponent<NPCLogic>().npcDialogue[activeNPC.GetComponent<NPCLogic>().npcData.interactionPoints]);
                        DialogueManager.Instance.givingRecipe = true;
                        UIManager.Instance.recipeBookUI.SetActive(false);
                        UIManager.Instance.mapUI.SetActive(false);
                    }
                    break;
                default: break;
            }
        }
        else Debug.Log("Cannot perform trade");

        InventoryLogic.Instance.DataToVisual();
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
        InventoryLogic.Instance.DataToVisual();

    }

    public void RecieveRecipe(Recipes recipe)
    {
        for (int i = 0; i < inventory.recipes.Length; i++)
        {
            if (inventory.recipes[i] == Recipes.None)
            {
                inventory.recipes[i] = recipe;
                NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcRecipe = Recipes.None;
                NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcData.givenRecipe = true;
                break;
            }
        }
    }
}
