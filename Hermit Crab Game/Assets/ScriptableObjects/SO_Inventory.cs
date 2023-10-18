using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
public class SO_Inventory : ScriptableObject
{
    public int stackSize = 5;

    public GameObject[] slot1 = new GameObject[5];
    public GameObject[] slot2 = new GameObject[5];
    public GameObject[] slot3 = new GameObject[5];
    public GameObject[] slot4 = new GameObject[5];
    public GameObject[] slot5 = new GameObject[5];
    public GameObject[] slot6 = new GameObject[5];
    public GameObject[] slot7 = new GameObject[5];
    public GameObject[] slot8 = new GameObject[5];
    public GameObject[] slot9 = new GameObject[5];
    public GameObject[] slot10 = new GameObject[5];

    public List<GameObject[]> ingredientInventory = new List<GameObject[]>();

    public GameObject dish;

    public GameObject[] recipes = new GameObject[6];
}
