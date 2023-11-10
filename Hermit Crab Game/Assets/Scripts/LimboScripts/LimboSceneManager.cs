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
        if (onDoorStep && touchingHouse) LoadHouse();
        else if (onTrigger && touchingCollider) LoadMossel();
        else if (doorEnter && touchWall) LoadLimbo();
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
}

