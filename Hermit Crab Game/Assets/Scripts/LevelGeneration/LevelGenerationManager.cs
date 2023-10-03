using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerationManager : MonoBehaviour
{
    public static LevelGenerationManager Instance { get; private set; }

    [Header("Chunks")]
    [SerializeField] private int max_amountOfChunks;
    [SerializeField] private GameObject p_chunk;
    [SerializeField] private List<GameObject> chunks = new List<GameObject>();
    [SerializeField] private List<GameObject> selectable_chunks = new List<GameObject>();
    [SerializeField] private Transform chunkParent;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChunkGenerator();
    }

    private void Update()
    {
    }

    private void ChunkGenerator()
    {
        for(int i = 0; i < max_amountOfChunks; i++)
        {
            if(chunks.Count == 0)
            {
                GameObject _chunk = Instantiate(p_chunk, Vector3.zero, Quaternion.identity, chunkParent);
                chunks.Add(_chunk);
            }
            else
            {
                SelectableChunkCheck();

                int randNum = Random.Range(0, selectable_chunks.Count);
                GameObject selectedChunk = null;

                for (int j = 0; j < selectable_chunks.Count; j++)
                {
                    if (j == randNum)
                    {
                        selectedChunk = selectable_chunks[j];
                    }
                }

                if (selectedChunk != null)
                {
                    GameObject _chunk = Instantiate(p_chunk, ChunkDirection(selectedChunk), Quaternion.identity, chunkParent);
                    chunks.Add(_chunk);
                }

                SelectableChunkCheck();
            }
        }
    }

    private void SelectableChunkCheck()
    {
        selectable_chunks.Clear();

        foreach(GameObject chunk in chunks)
        {
            if (!chunk.GetComponent<ChunkLogic>().locked)
            {
                selectable_chunks.Add(chunk);
            }
        }
    }

    private Vector3 ChunkDirection(GameObject selectedChunk)
    {
        List<Vector3> positions = new List<Vector3>();

        positions.Clear();

        if (!selectedChunk.GetComponent<ChunkLogic>().chunkDirection[0]) positions.Add(selectedChunk.transform.position + new Vector3(0, (selectedChunk.GetComponent<ChunkLogic>().chunkRadius * 2),0));
        if (!selectedChunk.GetComponent<ChunkLogic>().chunkDirection[1]) positions.Add(selectedChunk.transform.position + new Vector3(0, -(selectedChunk.GetComponent<ChunkLogic>().chunkRadius * 2), 0));
        if (!selectedChunk.GetComponent<ChunkLogic>().chunkDirection[2]) positions.Add(selectedChunk.transform.position + new Vector3(-(selectedChunk.GetComponent<ChunkLogic>().chunkRadius * 2), 0, 0));
        if (!selectedChunk.GetComponent<ChunkLogic>().chunkDirection[3]) positions.Add(selectedChunk.transform.position + new Vector3((selectedChunk.GetComponent<ChunkLogic>().chunkRadius * 2), 0, 0));

        int randInt = Random.Range(0,positions.Count);

        return positions[randInt];
    }
}
