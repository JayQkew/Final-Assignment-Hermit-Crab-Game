using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    #region UI Elements:
    public bool playerUIActive;
    public bool canOpenUI = true;

    public GameObject inventoryUI;
    public GameObject dishUI;
    public GameObject recipeBookUI;
    public GameObject mapUI;
    [SerializeField] private GameObject npcUI;

    public GameObject recipeBookButton;

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && canOpenUI) // show inventory
        {
            if (playerUIActive)
            {
                inventoryUI.SetActive(false);
                dishUI.SetActive(false);
                recipeBookUI.SetActive(false);
                InventoryLogic.Instance.DataToVisual();
                playerUIActive = false;
            }
            else if (!playerUIActive)
            {
                inventoryUI.SetActive(true);
                dishUI.SetActive(true);
                if (PlayerInventory.Instance.inventory.hasRecipeBook)
                {
                    recipeBookUI.SetActive(true);
                }
                InventoryLogic.Instance.DataToVisual();
                playerUIActive = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.M) &&
            canOpenUI &&
            MapManager.Instance.so_location.canFastTravel)
        {
            if (mapUI.activeSelf)
            {
                mapUI.SetActive(false);
                inventoryUI.SetActive(true);
                dishUI.SetActive(true);
                recipeBookUI.SetActive(true);
                InventoryLogic.Instance.DataToVisual();
                playerUIActive = true;
            }
            else
            {
                mapUI.SetActive(true);
                inventoryUI.SetActive(false);
                dishUI.SetActive(false);
                recipeBookUI.SetActive(false);
                InventoryLogic.Instance.DataToVisual();
                playerUIActive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.X)) // Throw items one by one
        {
            InventoryLogic.Instance.ThrowItems();
        }
        if (Input.GetKeyDown(KeyCode.C)) // Sort the whole inventory
        {
            InventoryLogic.Instance.SortInventory();
        }
    }

    public void NPCInteractionUI(bool open)
    {
        if (!open)
        {
            inventoryUI.SetActive(false);
            dishUI.SetActive(false);
            recipeBookUI.SetActive(false);
            npcUI.SetActive(true);
            NPCActionLogic.Instance.OpenActiveAction();
        }
        else npcUI.SetActive(false);
    }

    public void RecipeSelectMode()
    {
        recipeBookButton.GetComponent<RecipeBookButton>().OpenRecipeBook();
        inventoryUI.SetActive(true);
        dishUI.SetActive(true);
    }
}
