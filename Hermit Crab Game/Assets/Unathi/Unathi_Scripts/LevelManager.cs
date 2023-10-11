using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] int sceneLevel;

    public Transform[] locations;

    public Transform player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //sceneLevel = SceneManager.GetActiveScene().buildIndex;
        sceneLevel = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").transform;

        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            switch (sceneLevel)
            {
                case 0:
                    player.position = new Vector2(locations[0].position.x, locations[0].position.y);
                    break;
                case 1:
                    player.position = new Vector2(locations[1].position.x, locations[1].position.y);
                    break;
                case 2:
                    player.position = new Vector2(locations[2].position.x, locations[2].position.y);
                    break;
                case 3:
                    player.position = new Vector2(locations[3].position.x, locations[3].position.y);
                    break;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (sceneLevel < 3)
                {
                    sceneLevel++;
                }
                else if (sceneLevel == 3)
                {
                    sceneLevel = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (sceneLevel > 0)
                {
                    sceneLevel--;
                }
                else if (sceneLevel == 0)
                {
                    sceneLevel = 3;
                }
            }
        }

        

        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SelectLevel();
            }
        }

        if(SceneManager.GetActiveScene().name != "LevelSelect")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("LevelSelect");
            }
        }
    }

    public void SelectLevel()
    {
        switch (sceneLevel)
        {
            case 0:
                SceneManager.LoadScene("Level 1");
                break;
            case 1:
                SceneManager.LoadScene("Level 2");
                break;
            case 2:
                SceneManager.LoadScene("Level 3");
                break;
            case 3:
                SceneManager.LoadScene("Level 4");
                break;
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
