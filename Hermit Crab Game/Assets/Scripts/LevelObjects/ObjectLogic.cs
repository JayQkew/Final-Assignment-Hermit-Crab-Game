using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLogic : MonoBehaviour
{
    [Header("Unit Info")]
    public ObjectType objectType;
    public GameObject ingredient;

    //public GameObject wallParticle;

    public void Interact()
    {
        switch (objectType)
        {
            case ObjectType.Open:
                Open();
                break;
            case ObjectType.Shake:
                Shake();
                break;
            case ObjectType.Dig:
                Dig();
                break;
            case ObjectType.Cook:
                Cook();
                break;
        }
    }

    private void Shake()
    {
        if (ingredient != null)
        {
            Instantiate(ingredient, transform.position, Quaternion.identity, gameObject.transform);
            ingredient = null;
        }
    }

    private void Dig()
    {
        if (ingredient != null)
        {
            Instantiate(ingredient, transform.position, Quaternion.identity, gameObject.transform);
            ingredient = null;
        }
    }

    private void Open()
    {
        if (ingredient != null)
        {
            Instantiate(ingredient, transform.position, Quaternion.identity, gameObject.transform);
            ingredient = null;
        }
    }

    private void Cook()
    {
        UIManager.Instance.RecipeSelectMode();
    }
}

public enum ObjectType
{
    Open,
    Shake,
    Dig,
    Trade,
    Cook
}
