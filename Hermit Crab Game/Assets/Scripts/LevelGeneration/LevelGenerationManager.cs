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
    private bool typeChecked = false;
    #endregion

    #region INGREDIENTS AND OBJECTS
    [Header("Ingredients")]
    [SerializeField] private int maxSpawnAmount;
    [SerializeField] private int minSpawnAmount;
    [SerializeField] private int spawnAmount;
    [SerializeField] private GameObject[] ingredients;
    private bool ingredientsPlaced = false;

    [Header("Object")]
    [SerializeField] private float digPercentage; //use 0.___ for percentages
    [SerializeField] private float shakePercentage;
    [SerializeField] private float openPercentage;
    [Space(10)]
    [SerializeField] private int digAmount;
    [SerializeField] private int shakeAmount;
    [SerializeField] private int openAmount;
    [Space(10)]
    [SerializeField] private GameObject[] interactableObjects;
    [SerializeField] private List<GameObject> selectedObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> digObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> shakeObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> openObjects = new List<GameObject>();
    private bool objectsSelected = false;
    private bool objectsOrganised = false;
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

            if (!objectsOrganised) OrganizeObjects();

            if (!objectsSelected) SelectObjectsMain();

            if (!ingredientsPlaced) AddIngredients();
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

    private void SelectObjectsMain()
    {
        int _spawnAmount = Random.Range(minSpawnAmount, maxSpawnAmount);

        float _digAmount = _spawnAmount * digPercentage;
        float _shakeAmount = _spawnAmount * shakePercentage;
        float _openAmount = _spawnAmount * openPercentage;

        digAmount = Mathf.RoundToInt(_digAmount);
        shakeAmount = Mathf.RoundToInt(_shakeAmount);
        openAmount = Mathf.RoundToInt(_openAmount);

        spawnAmount = digAmount + shakeAmount + openAmount; //recalculates spawnAmount so that it always adds up

        SelectObjectSpecific(digObjects, digAmount);
        SelectObjectSpecific(shakeObjects, shakeAmount);
        SelectObjectSpecific(openObjects, openAmount);

        objectsSelected = true;
    }

    private void SelectObjectSpecific(List<GameObject> _objects, int amount)
    {
        int[] randomNumbers = new int[amount]; //make an array of random numbers

        for (int j = 0; j < amount; j++)
        {
            bool exists = false;
            int randNum = Random.Range(0, _objects.Count); //random number for objects

            for (int i = 0; i < amount; i++)
            {
                if (randNum == randomNumbers[i])
                {
                    exists = true;
                    break;
                }
            }
            if (!exists) randomNumbers[j] = randNum;
        }

        for (int i = 0; i < amount; i++)
        {
            selectedObjects.Add(_objects[randomNumbers[i]]);
        }
    }

    private void OrganizeObjects()
    {
        foreach (GameObject _object in interactableObjects)
        {
            switch (_object.GetComponent<ObjectLogic>().objectType)
            {
                case ObjectType.Dig:
                    digObjects.Add(_object);
                    break;
                case ObjectType.Shake:
                    shakeObjects.Add(_object);
                    break;
                case ObjectType.Open:
                    openObjects.Add(_object);
                    break;
            }
        }

        objectsOrganised = true;
    }
    private void AddIngredients()
    {
        foreach (GameObject _object in selectedObjects)
        {
            ObjectLogic objectLogic = _object.GetComponent<ObjectLogic>();

            foreach (GameObject ingredient in ingredients)
            {
                if (ingredient.GetComponent<IngredientLogic>().objectType == objectLogic.objectType)
                {
                    objectLogic.ingredient = ingredient;
                    break;
                }
            }
        }

        ingredientsPlaced = true;
    }

}

