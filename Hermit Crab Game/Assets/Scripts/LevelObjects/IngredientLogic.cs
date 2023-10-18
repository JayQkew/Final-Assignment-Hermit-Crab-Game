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

    Tomato,
    Onion,
    Mushrooms,
    Potato,
    Herbs,
    Mielies,
    Carrots,
    Beans,
    Garlic,
    Chillies,

    Meat,
    Vors,
    Chicken,
    Fish,
    Spices,
    MielieMeal,
    Oil,
    Butter,
    Bread,
    Chakalaka,
    Atchaar,
    Flour,
    Sugar
}
