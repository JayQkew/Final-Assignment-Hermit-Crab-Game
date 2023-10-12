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
    Potato,
    Tomato,
    Onion,
    Herbs,
    Mushrooms,
    Mielies,
    Carrots,
    Beans,
    Garlic,

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
