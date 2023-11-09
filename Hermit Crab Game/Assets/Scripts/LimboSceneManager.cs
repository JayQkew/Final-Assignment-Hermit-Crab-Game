using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LimboSceneManager : MonoBehaviour
{
    public Text questionText;
    public GameObject question;

    bool house;
    bool mossel;

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
            question.SetActive(true);
            if (gameObject.tag == "House")
            {
                house = true;
                mossel = false;
                questionText.text = "Enter the house?";
            }

            if (gameObject.tag == "Mossel")
            {
                mossel=true;
                house = false;
                questionText.text = "GO TO MOSSEL BAY?";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {
            question.SetActive(false);

        }
    }

    public void Button()
    {
        if (house)
        {
            LoadHouse();
        }               else if (mossel)
        {
            LoadMossel();
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

