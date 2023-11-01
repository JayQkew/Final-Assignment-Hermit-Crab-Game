using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCBase
{
    public bool tradeNpc;
    public string name;
    public NPCName npcName;
    public string profession;
    public int maxDialogue;
    public GameObject[] tradeIngredients;
    public GameObject[] costIngredients;
    public int[] costAmounts;

    public Sprite characterSprite;
}

public enum NPCName
{
    Ouma,
    Hadeda,
    Monkey,
    Meerkat,
    Ostrich,
    Mamba,
    Penguin,
    GirlHermitCrab
}
