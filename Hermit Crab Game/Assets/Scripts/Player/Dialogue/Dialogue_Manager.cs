using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue_Manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public int sentQueue;

    //public GameObject images; //Player and granny dialogue at level select (First time meeting)

    // Start is called before the first frame update
    void Awake()
    {
        sentences = new Queue<string>();

        if(SceneManager.GetActiveScene().name == "LevelSelect" && LevelManager.Instance.grannyIntro == true)
        {
            //images.SetActive(false);
        }
    }

    void Update()
    {

    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        Debug.Log("Starting dialogue with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            if (sentQueue == 0)
            {
                sentQueue = 1;
            }
            else if (sentQueue == 1)
            {
                sentQueue = 0;
            }
        }

            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
        
        

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;
        nameText.text = GameObject.Find("Hermit Crab").GetComponent<DialogueTrigger>().dialogue.name;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
        animator.SetBool("isOpen", false);

        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            LevelManager.Instance.grannyIntro = true;
        }
            
        StartCoroutine(LoadLevelSelect());
    }

    IEnumerator LoadLevelSelect()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Tutorial 1");

       // images.SetActive(false);
    }
}
