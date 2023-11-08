using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }
    public SO_Map so_location;

    public GameObject[] locations;

    [SerializeField] private GameObject map;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!map.activeSelf) return;
        AvailableLocations();
    }

    private void AvailableLocations()
    {
        for (int i  = 0; i < so_location.locations.Length; i++)
        {
            if (so_location.locations[i]) locations[i].SetActive(true);
            else locations[i].SetActive(false); 
        }
    }
}
