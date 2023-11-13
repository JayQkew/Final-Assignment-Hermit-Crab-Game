using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocationButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public SO_Locations location;
    public bool selected = false;
    private bool dataChecked = false;

    [SerializeField] private string locationName;
    [SerializeField] private Color startColour;
    [SerializeField] private Color hoverColour;

    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject p_images;
    [SerializeField] private List<GameObject> ingredientImages;
    [SerializeField] private List<GameObject> npcImages;

    [SerializeField] private GameObject[] p_ingredients;
    [SerializeField] private GameObject[] p_Npcs;
    private void Start()
    {
        startColour = GetComponent<Image>().color;
        locationName = gameObject.name.Trim();
    }

    private void Update()
    {
        if (!selected) return;

        infoPanel.SetActive(true);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        MapManager.Instance.selectecLocationName = "";

        foreach (GameObject locoButton in MapManager.Instance.locations)
        {
            if (locoButton != gameObject)
            {
                locoButton.GetComponent<LocationButton>().selected = false;
            }
            else
            {
                if (locationName == "MosselBay")
                {
                    MapManager.Instance.selectecLocationName = "Limbo";
                }
                else
                {
                    MapManager.Instance.selectecLocationName = locationName;
                }
                selected = true;
            }
        }

        GetComponent<Image>().color = hoverColour;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = hoverColour;
        infoPanel.SetActive(true);
        DataMatch();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = startColour;
        infoPanel.SetActive(false);
    }

    private void DataMatch()
    {
        if (!dataChecked)
        {
            foreach (IngredientType ingredient in location.availableIngredients)
            {
                foreach (GameObject _ingredient in p_ingredients)
                {
                    if (_ingredient.GetComponent<IngredientLogic>().ingredient == ingredient)
                    {
                        GameObject image = Instantiate(p_images, infoPanel.transform.GetChild(0));
                        image.GetComponent<Image>().sprite = _ingredient.GetComponent<SpriteRenderer>().sprite;
                        image.GetComponent<Image>().color = _ingredient.GetComponent<SpriteRenderer>().color;
                    }
                }
            }

            foreach (NPCName npc in location.localNPCs)
            {
                foreach (GameObject _npc in p_Npcs)
                {
                    if (_npc.GetComponent<NPCLogic>().npcBase.npcName == npc)
                    {
                        GameObject image = Instantiate(p_images, infoPanel.transform.GetChild(1));
                        image.GetComponent<Image>().sprite = _npc.GetComponentInChildren<SpriteRenderer>().sprite;
                        image.GetComponent<Image>().color = _npc.GetComponentInChildren<SpriteRenderer>().color;
                    }
                }
            }
            dataChecked = true;
        }

    }
}
