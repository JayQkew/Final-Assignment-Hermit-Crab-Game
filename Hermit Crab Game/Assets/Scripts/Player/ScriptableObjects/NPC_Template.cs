using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NPC", menuName = "Game/NPC")]
public class NPC_Template : ScriptableObject
{
    public string nPCName;
    public Animator anim;
    public List<bool> ingredients = new List<bool>();
}
