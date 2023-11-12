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
    public bool bribed;

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
            case NPCName.Hadeda:
            case NPCName.Mamba:
            case NPCName.GirlHermitCrab:
                ChillNPCs();
                break;
            case NPCName.Ouma:
                Ouma();
                break;
            case NPCName.Penguin:
                Penguin();
                break;
        }

        UIManager.Instance.NPCInteractionUI(false);
        NPCActionLogic.Instance.PersonaliseUI(this);

        DialogueManager.Instance.EnterDialogueMode(npcDialogue[npcData.interactionPoints - 1]); // change the array number depedning on the interactionPoints
        Debug.Log("Interaction points: " + npcData.interactionPoints);
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
                //normal food
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
                // give recipe/loco
                break;
            case 4:
                NPCChange(NPCActions.Interact, 1);
                // normal food
                break;
        }
    }

    private void Penguin()
    {
        switch (npcData.interactionPoints)
        {
            case 0:
                NPCChange(NPCActions.Converse, 1);
                break;
            case 1:
                NPCChange(NPCActions.Converse, 1);
                //bribe
                break;
            case 2:
                NPCChange(NPCActions.Converse, 1);
                // fave food -> give recipe
                break;
            case 4:
                NPCChange(NPCActions.Converse, 1);
                break;
            // normal food
            case 5:
                NPCChange(NPCActions.Converse, 1);
                //failed bride
                break;
        }
    }

    private void Ouma()
    {
        switch (npcData.interactionPoints)
        {
            case 0:
                NPCChange(NPCActions.Converse, 1); //meet in house -> tells plaer to meet outside
                break;
            case 1:
                NPCChange(NPCActions.Converse, 2); // meet at limbo -> tells player to forage
                break;
            case 2:
                NPCChange(NPCActions.Converse, 3); // at house when player finishes foraging -> teaches player how to cook + gives recipe + player goes to forage

                PlayerInventory.Instance.ClearInventory();

                PlayerInventory.Instance.inventory.slot1[0] = IngredientType.Meat;

                PlayerInventory.Instance.inventory.slot2[0] = IngredientType.Onion;

                PlayerInventory.Instance.inventory.slot3[0] = IngredientType.Herbs;
                PlayerInventory.Instance.inventory.slot3[1] = IngredientType.Herbs;

                PlayerInventory.Instance.inventory.slot4[0] = IngredientType.Tomato;
                PlayerInventory.Instance.inventory.slot4[1] = IngredientType.Tomato;
                PlayerInventory.Instance.inventory.slot4[2] = IngredientType.Tomato;
                PlayerInventory.Instance.inventory.slot4[3] = IngredientType.Tomato;

                PlayerInventory.Instance.inventory.slot5[0] = IngredientType.Garlic;
                PlayerInventory.Instance.inventory.slot5[1] = IngredientType.Garlic;

                PlayerInventory.Instance.inventory.slot6[0] = IngredientType.Potato;
                PlayerInventory.Instance.inventory.slot6[1] = IngredientType.Potato;
                PlayerInventory.Instance.inventory.slot6[2] = IngredientType.Potato;

                PlayerInventory.Instance.inventory.hasRecipeBook = true;
                UIManager.Instance.canOpenUI = true;
                PlayerInventory.Instance.RecieveRecipe(npcRecipe);
                npcData.givenRecipe = true;
                InventoryLogic.Instance.DataToVisual();
                break;
            case 3:
                ActionChange(NPCActions.Interact);
                break;
            case 4:
                NPCChange(NPCActions.Converse, 3);  
                break;
            case 5:
                NPCChange(NPCActions.Converse, 3);
                //failed bride
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
            if (NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcBase.npcName == NPCName.Ouma) NPCChange(NPCActions.Converse, 5);
            else NPCChange(NPCActions.Converse, 2);
            NPCActionLogic.Instance.OpenActiveAction();
            DialogueManager.Instance.givingLoco = true;
            DialogueManager.Instance.EnterDialogueMode(activeNPC.GetComponent<NPCLogic>().npcDialogue[activeNPC.GetComponent<NPCLogic>().npcData.interactionPoints]);
            NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcData.givenLoco = true;
            switch (NPCActionLogic.Instance.activeNPC.GetComponent<NPCLogic>().npcBase.npcName)
            {
                case NPCName.Ouma:
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

    #endregion
}

