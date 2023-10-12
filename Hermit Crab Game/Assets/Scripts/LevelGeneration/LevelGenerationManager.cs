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
    [SerializeField] private GameObject[] p_chunk; // Unathi changed this to an array
    [SerializeField] private Transform chunkParent;
    #endregion

    #region WALLS
    [Header("Walls")]
    public List<GameObject> walls = new List<GameObject>();
    public Transform wallParent;
    private bool wallsPlaced = false;
    private bool spaceChecked = false;
    private bool typeChecked = false;
    #endregion

    #region INGREDIENTS AND OBJECTS
    [Header("Ingredients and OBjects")]
    private bool objectsSelected = false;
    [SerializeField] private int maxSpawnAmount;
    [SerializeField] private int minSpawnAmount;
    [SerializeField] private int spawnAmount;
    [SerializeField] private GameObject[] ingredients;
    [SerializeField] private GameObject[] interactableObjects;
    [SerializeField] private List<GameObject> selectedObjects = new List<GameObject>();

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
            foreach (GameObject chunk in chunks)
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

            typeChecked = true;
        }

        if (typeChecked)
        {
            interactableObjects = GameObject.FindGameObjectsWithTag("interactableObject");

            if (!objectsSelected) SelectObjects();
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
            //Unathi Added random pick of chunk
            int rand = Random.Range(0, p_chunk.Length);
            GameObject chunk = Instantiate(p_chunk[rand], pos, Quaternion.identity, chunkParent);
            chunks.Add(chunk);
        }
    }

    private void SelectObjects()
    {
        spawnAmount = Random.Range(minSpawnAmount, maxSpawnAmount);

        int[] randNumbers = new int[spawnAmount];

        #region Random Number Check
        bool exists = false;
        int randomNumber = Random.Range(0, interactableObjects.Length);

        for(int i = 0; i < randNumbers.Length; i++) // checks if number already exists
        {
            if (randNumbers[i] == randomNumber)
            {
                exists = true;
                break;
            }
            if (!exists) randNumbers[i] = randomNumber;
        }

        #endregion

        for (int i = 0; i < spawnAmount; i++)
        {
            selectedObjects.Add(interactableObjects[randNumbers[i]]);
        }

        objectsSelected = true;
    }

    private void AddIngredients()
    {
        foreach(GameObject _object in selectedObjects)
        {
            ObjectLogic objectLogic = _object.GetComponent<ObjectLogic>();

            foreach(GameObject ingredient in ingredients)
            {
                if(ingredient.GetComponent<IngredientLogic>().objectType == objectLogic.objectType)
                {

                }
            }
        }
    }
}

