using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryLogic : MonoBehaviour
{
    public static InventoryLogic Instance { get; private set; }

    public SO_Inventory inventory;
    [SerializeField] private GameObject[] itemSlots = new GameObject[10];
    [SerializeField] private GameObject[] p_ingredient;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //AddItemSlots();
        DataToVisual();
    }

    public void DataToVisual()
    {
        for (int i = 0; i < inventory.ingredientInventory.Count; i++)
        {
            IngredientType ingredients = inventory.ingredientInventory[i][0];
            GameObject itemSlot = itemSlots[i];
            GameObject ui = itemSlot.GetComponent<ItemSlotLogic>().ui;
            GameObject text = itemSlot.transform.GetChild(1).gameObject;

            if (inventory.ingredientInventory[i][0] != IngredientType.Empty)
            {
                text.GetComponent<TextMeshProUGUI>().text = PlayerInventory.Instance.StackCount(inventory.ingredientInventory[i]).ToString();
                UISpriteMatch(ingredients, ui);
            }
            else
            {
                text.GetComponent<TextMeshProUGUI>().text = PlayerInventory.Instance.StackCount(inventory.ingredientInventory[i]).ToString();
                ui.GetComponent<Image>().color = Color.white;
            }
        }

        DishManager.Instance.UISpriteMatch(inventory.dish, DishManager.Instance.dishSlotUI);
        RecipeBookManager.Instance.RecipeBookMatch();
    }

    private void UISpriteMatch(IngredientType ingredient, GameObject ui)
    {
        Image image = ui.GetComponent<Image>();

        foreach (GameObject _ingredient in p_ingredient)
        {
            if (_ingredient.GetComponent<IngredientLogic>().ingredient == ingredient)
            {
                image.sprite = _ingredient.GetComponent<SpriteRenderer>().sprite;
                image.color = _ingredient.GetComponent<SpriteRenderer>().color;
                break;
            }
        }
    }

    public void ThrowItems()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].GetComponent<ItemSlotLogic>().selected)
            {
                inventory.ingredientInventory[i][PlayerInventory.Instance.StackCount(inventory.ingredientInventory[i]) - 1] = IngredientType.Empty;
                DataToVisual();
            }
        }
    }

    public void SortInventory()
    {
        List<IngredientType[]> availableSlots = new List<IngredientType[]>();

        foreach (IngredientType[] stack in inventory.ingredientInventory) // isolates the ones we're looking for
        {
            if (stack[0] != IngredientType.Empty && PlayerInventory.Instance.StackCount(stack) != inventory.stackSize)
            {
                availableSlots.Add(stack);
            }
        }

        foreach (IngredientType[] slot_a in availableSlots)
        {
            foreach (IngredientType[] slot_b in availableSlots)
            {
                if (slot_a[0] == slot_b[0] && slot_a != slot_b)
                {
                    IngredientType type = slot_a[0];
                    int totalStack = PlayerInventory.Instance.StackCount(slot_b) + PlayerInventory.Instance.StackCount(slot_a);

                    if (totalStack > 5)
                    {
                        int remainder = totalStack - 5;

                        ClearSlots(slot_a);
                        ClearSlots(slot_b);

                        FillSlots(slot_a, type, 5);
                        FillSlots(slot_b, type, remainder);
                    }
                    else if (totalStack == 5)
                    {
                        ClearSlots(slot_a);
                        ClearSlots(slot_b);

                        FillSlots(slot_a, type, 5);
                    }
                    else if (totalStack < 5)
                    {
                        ClearSlots(slot_a);
                        ClearSlots(slot_b);

                        FillSlots(slot_a, type, totalStack);
                    }

                    DataToVisual();
                }
            }
        }
    }

    private void ClearSlots(IngredientType[] slot)
    {
        for (int i = 0; i < slot.Length; i++)
        {
            slot[i] = IngredientType.Empty;
        }
    }

    private void FillSlots(IngredientType[] slot, IngredientType type, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            slot[i] = type;
        }
    }
}
