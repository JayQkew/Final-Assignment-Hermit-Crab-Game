using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryLogic : MonoBehaviour
{
    public static InventoryLogic Instance { get; private set; }

    [SerializeField] private SO_Inventory inventory;
    [SerializeField] private Transform inventoryParent;
    [SerializeField] private GameObject[] itemSlots = new GameObject[10];
    [SerializeField] private GameObject[] p_ingredient;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AddItemSlots();
        DataToVisual();
    }

    private void Update()
    {
    }

    private void AddItemSlots()
    {
        for (int i = 0; i < inventoryParent.childCount; i++)
        {
            itemSlots[i] = inventoryParent.GetChild(i).gameObject;
        }
    }

    public void DataToVisual()
    {
        for (int i = 0; i < inventory.ingredientInventory.Count; i++)
        {
            IngredientType ingredients = inventory.ingredientInventory[i][0];
            GameObject itemSlot = itemSlots[i];
            GameObject ui = itemSlot.transform.GetChild(0).gameObject;
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

}
