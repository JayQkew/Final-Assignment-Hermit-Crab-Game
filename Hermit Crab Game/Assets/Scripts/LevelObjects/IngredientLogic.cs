using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngredientLogic : MonoBehaviour
{
    public IngredientType ingredient;
    public ObjectType objectType;

    private void Start()
    {
        gameObject.name = ingredient.ToString();

        if (SceneManager.GetActiveScene().name == "Cooking")
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<PolygonCollider2D>().enabled = false;
        }
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
