using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientLogic : MonoBehaviour
{
    public IngredientType ingredient;
    public ObjectType objectType;

    private void Start()
    {
        gameObject.name = ingredient.ToString();
    }
}
public enum IngredientType
{
    Empty,

    Potato,
    Tomato,
    Onion,
    Herbs,
    Garlic,
    Carrots,
    Chillies,

    Meat,
    Wors,
    MielieMeal,
    Bread,
    Flour,
    Yeast,
    Atchaar,
    Curry,
    Spices
}
