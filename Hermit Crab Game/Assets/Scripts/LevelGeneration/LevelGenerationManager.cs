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
    [SerializeField] private GameObject[] p_chunk_level_1; // Unathi changed this to an array
    [SerializeField] private GameObject[] p_chunk_level_2;
    [SerializeField] private Transform chunkParent;
    #endregion

    #region WALLS
    [Header("Walls")]
    public List<GameObject> walls = new List<GameObject>();
    public Transform wallParent;
    private bool wallsPlaced = false;
    private bool spaceChecked = false;
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
                chunk.GetComponentInChildren<ChunkLogic>().ChunkOrWall();
            }

            wallsPlaced = true;
        }

        if (wallsPlaced)
        {
            foreach (GameObject wall in walls)
            {
                wall.GetComponentInChildren<WallLogic>().SpaceCheck();
            }

            spaceChecked = true;
        }

        if (spaceChecked)
        {
            foreach (GameObject wall in walls)
            {
                wall.GetComponentInChildren<WallTypeSelect>().TypeCheck();
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
        if (chunks.Count < maxChunks && LevelManager.Instance.sceneLevel==0)
        {
            //Unathi Added random pick of chunk
            int rand = Random.Range(0, p_chunk_level_1.Length);
            GameObject chunk = Instantiate(p_chunk_level_1[rand], pos, Quaternion.identity, chunkParent);
            chunks.Add(chunk);
        }

        if (chunks.Count < maxChunks && LevelManager.Instance.sceneLevel==1)
        {
            //Unathi Added random pick of chunk
            int rand = Random.Range(0, p_chunk_level_2.Length);
            GameObject chunk = Instantiate(p_chunk_level_2[rand], pos, Quaternion.identity, chunkParent);
            chunks.Add(chunk);
        }
    }
}
