using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerationManager : MonoBehaviour
{
    public static LevelGenerationManager Instance { get; private set; }

    public Grid grid;

    #region SEEKERS
    [Header("Seeker")]
    public List<GameObject> seekers = new List<GameObject>();
    [SerializeField] private int maxSeeker;
    [SerializeField] private GameObject p_seeker;
    [SerializeField] private Transform seekerParent;
    #endregion

    #region CHUNKS
    [Header("Chunks")]
    public List<GameObject> chunks = new List<GameObject>();
    [SerializeField] private int maxChunks;
    [SerializeField] private GameObject p_chunk;
    [SerializeField] private Transform chunkParent;
    #endregion

    #region WALLS
    [Header("Walls")]
    public Transform wallParent;
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SeekerSpawn(grid.GetCellCenterWorld(Vector3Int.zero));
        ChunkSpawn(grid.GetCellCenterWorld(Vector3Int.zero));
    }

    private void Update()
    {
        if (chunks.Count < maxChunks)
        {
            foreach (GameObject seeker in seekers)
            {
                seeker.GetComponent<SeekerLogic>().MoveSeeker();
                seeker.GetComponent<SeekerLogic>().ChooseAction();
            }
        }

        if (chunks.Count == maxChunks)
        {
            foreach(GameObject chunk in chunks)
            {
                chunk.GetComponent<ChunkLogic>().ChunkOrWall();
            }
        }
    }
    public void SeekerSpawn(Vector3 pos)
    {
        if (seekers.Count < maxSeeker)
        {
            GameObject seeker = Instantiate(p_seeker, pos, Quaternion.identity, seekerParent);
            seekers.Add(seeker);
        }
    }

    public void ChunkSpawn(Vector3 pos)
    {
        if (chunks.Count < maxChunks)
        {
            GameObject chunk = Instantiate(p_chunk, pos, Quaternion.identity, chunkParent);
            chunks.Add(chunk);
        }
    }
}
