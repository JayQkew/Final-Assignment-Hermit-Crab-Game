using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DishManager : MonoBehaviour
{
    public static DishManager Instance { get; private set; }
    public GameObject dishSlotUI;
    public GameObject giveButton;

    [SerializeField] private GameObject[] p_dishes;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (NPCActionLogic.Instance.npcAction != NPCActions.Give)
        {
            giveButton.SetActive(false);
            return;
        }

        giveButton.SetActive(true);
    }

    public void UISpriteMatch(Dishes dish, GameObject ui)
    {
        Image image = ui.GetComponent<Image>();

        foreach (GameObject _dish in p_dishes)
        {
            if (_dish.GetComponent<DishLogic>().dish == dish)
            {
                image.sprite = _dish.GetComponent<SpriteRenderer>().sprite;
                image.color = _dish.GetComponent<SpriteRenderer>().color;
                break;
            }
        }
    }

    public void GiveDish()
    {
        if (InventoryLogic.Instance.inventory.dish != Dishes.None)
        {
            NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().RecieveDish(InventoryLogic.Instance.inventory.dish);
            InventoryLogic.Instance.inventory.dish = Dishes.None;
            InventoryLogic.Instance.DataToVisual();
        }
    }

}
