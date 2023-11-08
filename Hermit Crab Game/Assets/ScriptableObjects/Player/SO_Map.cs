using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Maps", menuName = "ScriptableObjects/Maps", order = 3)]
public class SO_Map : ScriptableObject
{
    public bool canFastTravel = false;
    [Space(10)]
    public bool[] locations = new bool[5];
}
