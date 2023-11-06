using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    public SO_NPCData npcData;

    public NPCBase npcBase;

    public TextAsset[] npcDialogue;

    private void Start()
    {
    }

    public void Interact()
    {
        NPCActionLogic.Instance.activeNPC = gameObject;

        switch (npcBase.npcName)
        {
            case NPCName.Ouma:
                break;
            case NPCName.Hadeda:
                break;
            case NPCName.Monkey:
                MonkeyNPC();
                break;
            case NPCName.Meerkat:
                MeerkatNPC();
                break;
            case NPCName.Ostrich:
                OstrichNPC();
                break;
            case NPCName.Mamba:
                break;
            case NPCName.Penguin:
                break;
            case NPCName.GirlHermitCrab:
                break;
        }

        UIManager.Instance.NPCInteractionUI(false);
        NPCActionLogic.Instance.PersonaliseUI(this);

        DialogueManager.Instance.EnterDialogueMode(npcDialogue[npcData.dialoguePoints]); // change the array number depedning on the interactionPoints
    }

    public void CheckPoints()
    {
        switch (npcBase.npcName)
        {
            case NPCName.Ouma:
                break;
            case NPCName.Hadeda:
                break;
            case NPCName.Monkey:
                MonkeyNPC();
                break;
            case NPCName.Meerkat:
                MeerkatNPC();
                break;
            case NPCName.Ostrich:
                OstrichNPC();
                break;
            case NPCName.Mamba:
                break;
            case NPCName.Penguin:
                break;
            case NPCName.GirlHermitCrab:
                break;
        }

    }

    private void MonkeyNPC()
    {
        switch (npcData.interactionPoints)
        {
            case 0:
                NPCChange(NPCActions.Converse, 1, 1);
                break;
            case 1:
                ActionChange(NPCActions.Interact);
                break;
            case 2:
                NPCChange(NPCActions.Interact, 2);
                break;
            case 3:
                NPCChange(NPCActions.Interact, 1);
                break;
            case 4:
                NPCChange(NPCActions.Interact, 1);
                break;
            default:
                NPCChange(NPCActions.Interact, 0);
                break;
        }

    }
    private void OstrichNPC()
    {
        switch (npcData.interactionPoints)
        {
            case 0:
                NPCChange(NPCActions.Converse, 1, 1);
                break;
            case 1:
                ActionChange(NPCActions.Interact);
                break;
            case 2:
                NPCChange(NPCActions.Interact, 2);
                break;
            case 3:
                NPCChange(NPCActions.Interact, 1);
                break;
            case 4:
                NPCChange(NPCActions.Interact, 1);
                break;
            default:
                NPCChange(NPCActions.Interact, 0);
                break;
        }
    }
    private void MeerkatNPC()
    {
        switch (npcData.interactionPoints)
        {
            case 0:
                NPCChange(NPCActions.Converse, 1, 1);
                break;
            case 1:
                ActionChange(NPCActions.Interact);
                break;
            case 2:
                NPCChange(NPCActions.Interact, 2);
                break;
            case 3:
                NPCChange(NPCActions.Interact, 1);
                break;
            case 4:
                NPCChange(NPCActions.Interact, 1);
                break;
            default:
                NPCChange(NPCActions.Interact, 0);
                break;
        }
    }

    #region PUBLIC FUNCTIONS
    public void NPCChange(NPCActions action, int ipIncrease, int dpIncrease)
    {
        NPCActionLogic.Instance.npcAction = action;
        npcData.interactionPoints += ipIncrease;
        npcData.dialoguePoints += dpIncrease;
    }
    public void NPCChange(NPCActions action, int ipIncrease)
    {
        NPCActionLogic.Instance.npcAction = action;
        npcData.interactionPoints += ipIncrease;
    }
    public void IPChange(int ipIncrease) => npcData.interactionPoints += ipIncrease;
    public void DPChange(int dpIncrease) => npcData.dialoguePoints += dpIncrease;
    public void ActionChange(NPCActions action) => NPCActionLogic.Instance.npcAction = action;
    #endregion
}

