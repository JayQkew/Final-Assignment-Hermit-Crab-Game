using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Locations", menuName = "ScriptableObjects/Locations", order = 4)]
public class SO_Locations : ScriptableObject
{
    public IngredientType[] availableIngredients;
    public NPCName[] localNPCs;
    public bool[] metNPCs;
}
