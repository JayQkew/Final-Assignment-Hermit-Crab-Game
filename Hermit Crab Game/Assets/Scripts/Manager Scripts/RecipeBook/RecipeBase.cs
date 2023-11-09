using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecipeBase
{
    public IngredientType[] ingredientsNeeded;
    public int[] amountRequired;
    public string recipeName;
}
