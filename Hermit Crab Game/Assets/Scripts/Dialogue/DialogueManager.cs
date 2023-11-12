using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public bool givingRecipe = false;
    public bool givingLoco = false;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Story currentDialogue;
    [SerializeField] public bool dialoguePlaying;

    #region Parsing
    private const string characterTag = "character";
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        dialoguePlaying = false;
    }

    private void Update()
    {
        if (!dialoguePlaying) return; //return right away when dialogue isn't playing

        if (Input.GetMouseButtonDown(0)) ContinueStory();

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        UIManager.Instance.inventoryUI.SetActive(false);
        UIManager.Instance.dishUI.SetActive(false);
        UIManager.Instance.recipeBookUI.SetActive(false);
        UIManager.Instance.mapUI.SetActive(false);
        dialoguePlaying = true;
        currentDialogue = new Story(inkJSON.text);
        //ContinueStory();
    }

    public void ExitDialogueMode()
    {
        dialoguePlaying = false;
        dialogueText.text = "";
        nameText.text = "";

        if (SceneManager.GetActiveScene().name == "Tutorial 2")
        {
            SceneManager.LoadScene("Tutorial 3");
        }

        NPCActionLogic.Instance.ChangeAction(NPCActions.Interact);
        //NPCActionLogic.Instance.IPChange(1);
        NPCActionLogic.Instance.OpenActiveAction();

    }

    public void ContinueStory()
    {
        if (currentDialogue.canContinue)
        {
            dialogueText.text = currentDialogue.Continue(); // give us the next line of dialogue
            HandleTags(currentDialogue.currentTags);
        }
        else
        {
            if (givingRecipe)
            {
                PlayerInventory.Instance.RecieveRecipe(NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcRecipe);
                givingRecipe = false;
            }
            if (givingLoco)
            {
                // reveal the new locaiton
                // use NPCLogic function
                givingLoco = false;
            }
            ExitDialogueMode();
        }
    }

    public void HandleTags(List<string> tags)
    {
        foreach (string tag in tags)
        {
            string[] splitTag = tag.Split(':');

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case characterTag:
                    nameText.text = tagValue;
                    break;
            }
        }
    }
}
