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
            case NPCName.Monkey:
            case NPCName.Meerkat:
            case NPCName.Ostrich:
                TradeNPCs();
                break;
            case NPCName.Ouma:
                break;
            case NPCName.Hadeda:
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

    private void ChillNPCs()
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
                break;
            case 4:
                NPCChange(NPCActions.Interact, 1);
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
            switch (NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcBase.npcName)
            {
                case NPCName.Ouma:
                    //ouma ending dialogue
                    break;
                case NPCName.Hadeda:
                    MapManager.Instance.so_location.canFastTravel = true;
                    MapManager.Instance.so_location.locations[0] = true;
                    MapManager.Instance.so_location.locations[1] = true;
                    MapManager.Instance.so_location.locations[2] = true;
                    break;
                case NPCName.Monkey:
                    MapManager.Instance.so_location.locations[3] = true;
                    break;
                case NPCName.Meerkat:
                    MapManager.Instance.so_location.locations[3] = true;
                    break;
                case NPCName.Ostrich:
                    MapManager.Instance.so_location.locations[3] = true;
                    break;
                case NPCName.Mamba:
                    // give new area and new recipe
                    MapManager.Instance.so_location.locations[4] = true;
                    PlayerInventory.Instance.RecieveRecipe(npcRecipe);
                    break;
                case NPCName.Penguin:
                    PlayerInventory.Instance.RecieveRecipe(npcRecipe);
                    break;
                case NPCName.GirlHermitCrab:
                    PlayerInventory.Instance.RecieveRecipe(npcRecipe);
                    break;
                default:
                    break;
            }
        }
        else if (dish != Dishes.None)
        {
            NPCChange(NPCActions.Converse, 4); //recieves any other dishes
            NPCActionLogic.Instance.OpenActiveAction();
            DialogueManager.Instance.EnterDialogueMode(activeNPC.GetComponent<NPCLogic>().npcDialogue[activeNPC.GetComponent<NPCLogic>().npcData.interactionPoints]);

        }
    }

    public void RevealLoco()
    {

    }
    #endregion
}

