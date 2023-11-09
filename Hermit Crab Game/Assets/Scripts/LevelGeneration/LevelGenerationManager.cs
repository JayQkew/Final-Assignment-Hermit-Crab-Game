using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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
    [SerializeField] private GameObject[] p_chunk;
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
    [SerializeField] private GameObject[] ingredients;
    private int spawnAmount;
    private List<GameObject> digIngredients = new List<GameObject>();
    private List<GameObject> shakeIngredients = new List<GameObject>();
    private List<GameObject> openIngredients = new List<GameObject>();
    private bool ingredientsPlaced = false;

    [Header("Object")]
    [SerializeField, Tooltip("Make sure percentages add up to a total of 1")] private float digPercentage; //use 0.___ for percentages
    [SerializeField, Tooltip("Make sure percentages add up to a total of 1")] private float shakePercentage;
    [SerializeField, Tooltip("Make sure percentages add up to a total of 1")] private float openPercentage;
    [Space(10)]
    private GameObject[] interactableObjects;
    private int digAmount;
    private int shakeAmount;
    private int openAmount;
    private List<GameObject> taggedObjects = new List<GameObject>();
    private List<GameObject> stampedObjects = new List<GameObject>();
    private List<GameObject> digObjects = new List<GameObject>();
    private List<GameObject> shakeObjects = new List<GameObject>();
    private List<GameObject> openObjects = new List<GameObject>();
    private bool objectsSelected = false;
    private bool objectsOrganised = false;
    private bool ingredientsAllAdded = false;
    #endregion

    #region NPC SPAWN
    [Header("NPCs")]
    [SerializeField] private GameObject[] npcSpawnPoints;
    [SerializeField] private Transform npcParent;
    [SerializeField, Tooltip("add npc prefabs here")] private GameObject[] npcs;
    private bool npcsSpawned = false;
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
            interactableObjects = GameObject.FindGameObjectsWithTag("interactableObject"); // add all interactable objects to an array

            if (!objectsOrganised) OrganizeObjectsAndIngredients();

            if (!objectsSelected) SelectObjectsMain();

            if (!ingredientsPlaced) AddIngredients();

            ingredientsAllAdded = true;
        }

        if (ingredientsAllAdded)
        {
            npcSpawnPoints = GameObject.FindGameObjectsWithTag("npcSpawn");

            if (!npcsSpawned) SpawnNPCs();
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
        if (chunks.Count < maxChunks /*&& LevelManager.Instance.sceneLevel==0*/)
        {
            //Unathi Added random pick of chunk
            int rand = Random.Range(0, p_chunk.Length);
            GameObject chunk = Instantiate(p_chunk[rand], pos, Quaternion.identity, chunkParent);
            chunks.Add(chunk);
        }
    }

    private void SelectObjectsMain()
    {
        int _spawnAmount = Random.Range(minSpawnAmount, maxSpawnAmount); // random range for amount of ingredients to spawn

        //amount to spawn for each type of ingredient
        float _digAmount = _spawnAmount * digPercentage;
        float _shakeAmount = _spawnAmount * shakePercentage;
        float _openAmount = _spawnAmount * openPercentage;

        // makes it an integer
        digAmount = Mathf.RoundToInt(_digAmount);
        shakeAmount = Mathf.RoundToInt(_shakeAmount);
        openAmount = Mathf.RoundToInt(_openAmount);

        spawnAmount = digAmount + shakeAmount + openAmount; //recalculates spawnAmount so that it always adds up

        TagSelectedObjects(digObjects, digAmount);
        TagSelectedObjects(shakeObjects, shakeAmount);
        TagSelectedObjects(openObjects, openAmount);

        objectsSelected = true;
    }

    private void OrganizeObjectsAndIngredients() // organise the interactable objects into thier respective lists
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

        AmountOfIngredientTypes(); // sort the ingredients 

        objectsOrganised = true;
    }

    private void AddIngredients()
    {
        for (int i = 0; i < taggedObjects.Count; i++)
        {
            ObjectLogic objectLogic = taggedObjects[i].GetComponent<ObjectLogic>();
            objectLogic.ingredient = ChosenIngredient(objectLogic.objectType);
            stampedObjects.Add(taggedObjects[i]);
        }

        ingredientsPlaced = true;
    }

    private void TagSelectedObjects(List<GameObject> _objects, int amount)
    {
        int[] randomNumbers = new int[amount]; //make an array for random numbers

        for (int j = 0; j < amount; j++) // add non-existent numbers to the array for random objects
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
            taggedObjects.Add(_objects[randomNumbers[i]]);
        }
    }

    private void AmountOfIngredientTypes()
    {
        foreach (GameObject ingredient in ingredients)
        {
            switch (ingredient.GetComponent<IngredientLogic>().objectType)
            {
                case ObjectType.Open:
                    openIngredients.Add(ingredient);
                    break;
                case ObjectType.Shake:
                    shakeIngredients.Add(ingredient);
                    break;
                case ObjectType.Dig:
                    digIngredients.Add(ingredient);
                    break;
                default:
                    break;
            }
        }

    }

    private GameObject ChosenIngredient(ObjectType type)
    {
        int splitAmount;
        switch (type)
        {
            case ObjectType.Open:
                splitAmount = openAmount / openIngredients.Count;
                return ChooseIngredient(type, splitAmount, openIngredients);
            case ObjectType.Shake:
                splitAmount = shakeAmount / shakeIngredients.Count;
                return ChooseIngredient(type, splitAmount, shakeIngredients);
            case ObjectType.Dig:
                splitAmount = digAmount / digIngredients.Count;
                return ChooseIngredient(type, splitAmount, digIngredients);
            default:
                return null;
        }
    }

    private GameObject ChooseIngredient(ObjectType type, int splitAmount, List<GameObject> ingredientsList)
    {
        GameObject chosenIngredient = null;

        foreach (GameObject ingredient in ingredientsList)
        {
            int ingredientCount = 0;

            if (stampedObjects.Count == 0 && ingredientCount == 0)
            {
                ingredientCount++;
                chosenIngredient = ingredientsList[0];
            }
            else
            {
                for (int i = 0; i < stampedObjects.Count; i++) // loop through stamped objects
                {
                    IngredientType objectIngredient = stampedObjects[i].GetComponent<ObjectLogic>().ingredient.GetComponent<IngredientLogic>().ingredient;
                    IngredientType ingredientType = ingredient.GetComponent<IngredientLogic>().ingredient;

                    if (objectIngredient == ingredientType) ingredientCount++;

                }

                if (ingredientCount <= splitAmount)
                {
                    chosenIngredient = ingredient;
                    return chosenIngredient;
                }

            }
        }

        return chosenIngredient;
    }

    private void SpawnNPCs()
    {
        int[] randomNumbers = new int[npcs.Length];

        for (int i = 0; i < randomNumbers.Length; i++) randomNumbers[i] = Random.Range(0, npcSpawnPoints.Length - 1);

        for(int i = 0; i < npcs.Length; i++)
        {
            Instantiate(npcs[i], npcSpawnPoints[i].transform.position, Quaternion.identity, npcParent);
        }

        npcsSpawned = true;
    }
}

