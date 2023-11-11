using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Manager : MonoBehaviour
{
    public Transform[] spawnPoints;

    // Add a spawn point to the array
    public void AddSpawnPoint(Transform spawnPoint)
    {
        // Resize the array and add the new spawn point
        System.Array.Resize(ref spawnPoints, spawnPoints.Length + 1);
        spawnPoints[spawnPoints.Length - 1] = spawnPoint;
    }
}
