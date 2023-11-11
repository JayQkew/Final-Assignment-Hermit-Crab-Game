using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LimboSceneManager : MonoBehaviour
{
    public static LimboSceneManager Instance { get; private set; }

    [Header("House")]
    public bool onDoorStep;
    public bool touchingHouse;

    [Header("Mossel Bay")]
    public bool onTrigger;
    public bool touchingCollider;

    [Header("Limbo")]
    public bool doorEnter;
    public bool touchWall;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial 3")
        {
            if (onTrigger && touchingCollider) LoadTutorial4();
        }
        else if (SceneManager.GetActiveScene().name == "Tutorial 2")
        {
            if (doorEnter && touchWall) LoadTutorial3();
        }
        else if (SceneManager.GetActiveScene().name == "Tutorial 1")
        {
            if (onDoorStep && touchingHouse) LoadTutorial2();
        }
        else
        {
            if (onDoorStep && touchingHouse) LoadHouse();
            else if (onTrigger && touchingCollider) LoadMossel();
            else if (doorEnter && touchWall) LoadLimbo();
        }


    }


    void LoadMossel()
    {
        SceneManager.LoadScene("MosselBay");
    }

    void LoadHouse()
    {
        SceneManager.LoadScene("House");
    }

    void LoadLimbo()
    {
        SceneManager.LoadScene("Limbo");
    }

    void LoadTutorial4()
    {
        SceneManager.LoadScene("Tutorial 4");
    }

    void LoadTutorial3()
    {
        SceneManager.LoadScene("Tutorial 3");
    }
    void LoadTutorial2()
    {
        SceneManager.LoadScene("Tutorial 2");
    }

}

