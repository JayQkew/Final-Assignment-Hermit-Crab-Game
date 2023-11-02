using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Intro" || SceneManager.GetActiveScene().name == "LevelSelect" && LevelManager.Instance.grannyIntro == false)
        StartCoroutine(StartDialogue());
    }

    void Update()
    {
        if (GameObject.Find("DialogueManager").GetComponent<DialogueManager>().sentQueue == 0)
        {
            dialogue.name = "Granny";
        }
        else if (GameObject.Find("DialogueManager").GetComponent<DialogueManager>().sentQueue == 1)
        {
            dialogue.name = "Herbert";
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(2);

        TriggerDialogue();

    }
}
