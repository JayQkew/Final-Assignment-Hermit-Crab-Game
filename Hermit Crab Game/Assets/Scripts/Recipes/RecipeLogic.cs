using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeLogic : MonoBehaviour
{
    public Recipes recipe;
    public RecipeBase recipeBase;
    public GameObject dish;


}

public enum Recipes
{
    None,

    OumasPotjieKos,
    BraaiKos,
    PapNKos,
    BunnyChow,
    Vetkoek,
    Kota,
    RoosterkoekChips,
    YourPotjieOne,
    YourPotjieTwo
}
