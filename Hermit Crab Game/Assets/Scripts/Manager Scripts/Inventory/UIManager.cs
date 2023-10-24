using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    #region UI Elements:
    [SerializeField] private GameObject inventoryUI;
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // show inventory
        {
            if (inventoryUI.activeSelf) inventoryUI.SetActive(false);
            else
            {
                inventoryUI.SetActive(true);
                InventoryLogic.Instance.DataToVisual();
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

}
