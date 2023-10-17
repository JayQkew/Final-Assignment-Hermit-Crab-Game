using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
public class SO_Inventory : ScriptableObject
{
    public GameObject[,] ingredientInventory = new GameObject[10, 5]; // [ DifferentObjects, ObjectStack ]
    public GameObject dish;

    public GameObject[] recipes = new GameObject[6];
}
