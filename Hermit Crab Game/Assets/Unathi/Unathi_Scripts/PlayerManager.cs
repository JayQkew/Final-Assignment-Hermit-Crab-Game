using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    LevelGenerationManager level;

    public Transform player;

      // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("LevelGenerationManager").GetComponent<LevelGenerationManager>();

        StartCoroutine(SpawnPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(1.5f);

        // Can Add Some Load Screen Logic

        int randChunk = Random.Range(0, level.chunks.Count);

        Transform chunk = level.chunks[randChunk].transform;

        player.position = chunk.position;
    }
}
