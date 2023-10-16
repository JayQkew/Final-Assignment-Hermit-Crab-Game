using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public SO_Inventory inventory;

    private void Awake()
    {
        Instance = this;
    }
}
