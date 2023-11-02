using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public int sceneLevel;

    public bool level = false;
    public bool grannyIntro = false;

    public LevelProperties levelProperties;

    //Locked Levels
    public bool level2a;
    public bool level2b;
    public bool level3;
    public bool level4;

    // Start is called before the first frame update
    void Start()
    {
        //sceneLevel = SceneManager.GetActiveScene().buildIndex;
        sceneLevel = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (sceneLevel < 4)
                {
                    sceneLevel++;
                }
                else if (sceneLevel == 4)
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
                    sceneLevel = 4;
                }
            }
        }

        

        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            if (Input.GetMouseButtonDown(0) && level)
            {
                Debug.Log("Left mouse button pressed");
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
                if (level2a)
                SceneManager.LoadScene("Level 2a");
                break;
            case 2:
                if(level2b)
                SceneManager.LoadScene("Level 2b");
                break;
            case 3:
                if(level3)
                SceneManager.LoadScene("Level 3");
                break;
            case 4:
                if (level4)
                SceneManager.LoadScene("Level 4");
                break;
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    // Example function to unlock the next level
    public void TryToUnlockNextLevel(int currentLevel)
    {
        if (levelProperties.CanUnlockNextLevel(currentLevel))
        {
            levelProperties.UnlockNextLevel();
            Debug.Log("Next level unlocked!");
        }
        else
        {
            Debug.Log("Can't unlock the next level yet. Complete more requests.");
        }
    }

    // Example function to reset the level progression
    public void ResetLevelProgress()
    {
                levelProperties.ResetProgress();
                Debug.Log("Level progression reset.");
    }

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
}
