using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class RecipeBookManager : MonoBehaviour
{
    public static RecipeBookManager Instance { get; private set; }

    public GameObject activePage;
    [SerializeField] private GameObject recipeBookPanel;
    [SerializeField] private GameObject recipeBookButton;
    [SerializeField] private GameObject[] pages;

    private void Awake()
    {
        Instance = this;
    }

    public void RecipeBookMatch()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (!pages[i].GetComponent<PageLogic>().pageSet)
            {
                pages[i].GetComponent<PageLogic>().recipe = InventoryLogic.Instance.inventory.recipes[i];
            }
        }

        foreach (GameObject page in pages)
        {
            page.GetComponent<PageLogic>().SetPage();
            page.GetComponent<PageLogic>().ActiveCheck();
            if (page.transform.GetSiblingIndex() != 8) page.SetActive(false);
            else page.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        recipeBookPanel.SetActive(false);
        recipeBookButton.SetActive(true);
    }
    public void PageChange(int upOrDown)
    {
        int activeIndex = 0;
        int nextIndex = 0;
        foreach (GameObject page in pages)
        {
            if (page.GetComponent<PageLogic>().pageActive)
            {
                activeIndex = page.GetComponent<PageLogic>().pageIndex;
                nextIndex = activeIndex + upOrDown;
                if (nextIndex == -1) nextIndex = pages.Length - 1;
                else if (nextIndex == 9) nextIndex = 0;
                break;
            }
        }

        foreach (GameObject page in pages)
        {
            if (page.GetComponent<PageLogic>().pageIndex == nextIndex) page.GetComponent<PageLogic>().pageActive = true;
            else page.GetComponent<PageLogic>().pageActive = false;
        }

        foreach (GameObject page in pages)
        {
            page.GetComponent<PageLogic>().ActiveCheck();
            page.GetComponent<PageLogic>().selected = false;
            if (page.transform.GetSiblingIndex() != 8) page.SetActive(false);
            else page.SetActive(true);
        }
    }
}
