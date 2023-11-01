using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC name", menuName = "ScriptableObjects/NPC data", order = 2)]
public class SO_NPCData : ScriptableObject
{
    public int interactionPoints = 0;
    public int dialoguePoints = 0;
    public bool[] dialogueBool;

    public bool givenLoco = false;
    public bool givenRecipe = false;
}
