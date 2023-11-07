using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    public SO_NPCData npcData;
    public NPCBase npcBase;
    public TextAsset[] npcDialogue;

    public Recipes npcRecipe;
    public Dishes favDish;

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
            case NPCName.Meerkat:
            case NPCName.Ostrich:
                TradeNPCs();
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

        DialogueManager.Instance.EnterDialogueMode(npcDialogue[npcData.interactionPoints]); // change the array number depedning on the interactionPoints
    }

    private void TradeNPCs()
    {
        switch (npcData.interactionPoints)
        {
            case 0:
                NPCChange(NPCActions.Converse, 1);
                break;
            case 1:
                ActionChange(NPCActions.Interact);
                break;
            case 2:
                NPCChange(NPCActions.Interact, 1);
                // reveal a loco to the player
                break;
            case 3:
                NPCChange(NPCActions.Interact, 1);
                // give player recipe for trading
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
    public void NPCChange(NPCActions action, int ipIncrease)
    {
        NPCActionLogic.Instance.npcAction = action;
        npcData.interactionPoints = ipIncrease;
    }
    public void IPChange(int ipIncrease) => npcData.interactionPoints = ipIncrease;
    public void ActionChange(NPCActions action) => NPCActionLogic.Instance.npcAction = action;

    public void RecieveDish(Dishes dish)
    {
        GameObject activeNPC = NPCActionLogic.Instance.activeNPC;

        if (dish == favDish)
        {
            NPCChange(NPCActions.Converse, 2);
            NPCActionLogic.Instance.OpenActiveAction();
            DialogueManager.Instance.givingLoco = true;
            DialogueManager.Instance.EnterDialogueMode(activeNPC.GetComponent<NPCLogic>().npcDialogue[activeNPC.GetComponent<NPCLogic>().npcData.interactionPoints]);
            NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcData.givenLoco = true;
            Debug.Log("fav dishhhh!!");
        }
        else if (dish != Dishes.None)
        {
            NPCChange(NPCActions.Converse, 4); //recieves any other dishes
            NPCActionLogic.Instance.OpenActiveAction();
            DialogueManager.Instance.EnterDialogueMode(activeNPC.GetComponent<NPCLogic>().npcDialogue[activeNPC.GetComponent<NPCLogic>().npcData.interactionPoints]);
            Debug.Log("meh its alright");
        }
    }

    public void RevealLoco()
    {

    }
    #endregion
}

