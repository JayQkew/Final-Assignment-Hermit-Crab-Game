using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

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
        dialoguePlaying = true;
        currentDialogue = new Story(inkJSON.text);
        ContinueStory();
    }

    public void ExitDialogueMode()
    {
        dialoguePlaying = false;
        dialogueText.text = "";
        nameText.text = "";
        NPCActionLogic.Instance.ChangeAction(NPCActions.Interact);
    }

    public void ContinueStory()
    {
        if (currentDialogue.canContinue)
        {
            dialogueText.text = currentDialogue.Continue(); // give us the next line of dialogue
            HandleTags(currentDialogue.currentTags);
        }
        else ExitDialogueMode();
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
