using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_SpawnPoint : MonoBehaviour
{
    public NPC_Manager npcManager;

    void Start()
    {
        npcManager = GameObject.Find("Npcs").GetComponent<NPC_Manager>();

        // Access the array of spawn points from NPC_Manager
        Transform[] spawnPoints = npcManager.spawnPoints;

            // Add this spawn point's transform to the NPC Manager
            npcManager.AddSpawnPoint(transform);
    }
}
