using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public int sceneLevel;

    public bool level = false;

    public LevelProperties[] levelProperties;

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
                SceneManager.LoadScene("Level 2");
                break;
            case 2:
                SceneManager.LoadScene("Level 3");
                break;
            case 3:
                SceneManager.LoadScene("Level 4");
                break;
            case 4:
                SceneManager.LoadScene("Level 5");
                break;
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    // This is all temporary, I'll fix it up
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
        switch (sceneLevel)
        {
            case 0:
                levelProperties[0].ResetProgress();
                Debug.Log("Level progression reset.");
                break;
            case 1:
                levelProperties[1].ResetProgress();
                Debug.Log("Level progression reset.");
                break;
            case 2:
                levelProperties[2].ResetProgress();
                Debug.Log("Level progression reset.");
                break;
            case 3:
                levelProperties[3].ResetProgress();
                Debug.Log("Level progression reset.");
                break;
            case 4:
                levelProperties[4].ResetProgress();
                Debug.Log("Level progression reset.");
                break;
        }
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
