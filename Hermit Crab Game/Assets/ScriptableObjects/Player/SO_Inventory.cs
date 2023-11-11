using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
public class SO_Inventory : ScriptableObject
{
    public int stackSize = 5;

    public IngredientType[] slot1 = new IngredientType[5];
    public IngredientType[] slot2 = new IngredientType[5];
    public IngredientType[] slot3 = new IngredientType[5];
    public IngredientType[] slot4 = new IngredientType[5];
    public IngredientType[] slot5 = new IngredientType[5];
    public IngredientType[] slot6 = new IngredientType[5];
    public IngredientType[] slot7 = new IngredientType[5];
    public IngredientType[] slot8 = new IngredientType[5];
    public IngredientType[] slot9 = new IngredientType[5];
    public IngredientType[] slot10 = new IngredientType[5];

    public List<IngredientType[]> ingredientInventory = new List<IngredientType[]>();

    public Dishes dish;

    public bool hasRecipeBook = false;
    public Recipes[] recipes = new Recipes[9];
}
