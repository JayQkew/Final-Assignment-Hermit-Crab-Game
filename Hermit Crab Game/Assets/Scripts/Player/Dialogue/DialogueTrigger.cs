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
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            if (GameObject.Find("DialogueManager").GetComponent<Dialogue_Manager>().sentQueue == 0)
            {
                dialogue.name = "Granny";
            }
            else if (GameObject.Find("DialogueManager").GetComponent<Dialogue_Manager>().sentQueue == 1)
            {
                dialogue.name = "Herbert";
            }
        }
        
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogue);
    }

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(2);

        TriggerDialogue();

    }
}
