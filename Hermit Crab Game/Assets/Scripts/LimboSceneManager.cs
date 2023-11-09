using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LimboSceneManager : MonoBehaviour
{
    public Text questionText;
    public GameObject question; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if(gameObject.tag == "House")
            {
                questionText.text = "Enter the house?";
            }

            if (gameObject.tag == "Mossel")
            {
                questionText.text = "GO TO MOSSEL BAY?";
            }
        }
    }

    void LoadMossel()
    {
        SceneManager.LoadScene("Level 1");
    }

    void LoadHouse()
    {
        SceneManager.LoadScene("House");
    }
}
