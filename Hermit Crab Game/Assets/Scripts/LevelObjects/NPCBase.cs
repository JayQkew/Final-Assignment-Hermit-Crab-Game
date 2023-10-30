using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCBase
{
    public bool tradeNpc;
    public string name;
    public string profession;
    public GameObject[] tradeIngredients;
    public GameObject[] costIngredients;
    public int[] costAmounts;

    public Sprite characterSprite;
}
