using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NPCActionLogic : MonoBehaviour
{
    public static NPCActionLogic Instance { get; private set; }

    public NPCActions npcAction;
    public GameObject activeNPC;

    [Header("Action UI")]
    [SerializeField] private GameObject interactUI;
    [SerializeField] private GameObject converseUI;
    [SerializeField] private GameObject tradeUI;
    [SerializeField] private GameObject giveUI;

    [SerializeField] private GameObject[] npcDisplay;
    [SerializeField] private GameObject npcTradeInteract;

    [SerializeField] private GameObject p_tradeButton;
    [SerializeField] private Transform tradeParent;
    [SerializeField] private List<GameObject> tradeButtons = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    public void PersonaliseUI(NPCLogic npcLogic)
    {
        ChangeNPCDisplay(npcLogic);
        ChangeNPCInteractables(npcLogic);
        if (npcLogic.npcBase.tradeNpc) ChangeNPCTrades(npcLogic);
    }

    private void ChangeNPCDisplay(NPCLogic npcLogic)
    {
        Sprite characterSprite = npcLogic.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        Color spriteColour = npcLogic.gameObject.GetComponentInChildren<SpriteRenderer>().color;

        foreach (GameObject display in npcDisplay)
        {
            display.GetComponent<Image>().sprite = characterSprite;
            display.GetComponent<Image>().color = spriteColour;
        }
    }
    private void ChangeNPCInteractables(NPCLogic npcLogic)
    {
        if (npcLogic.npcBase.tradeNpc) npcTradeInteract.SetActive(true);
        else npcTradeInteract.SetActive(false);
    }
    private void ChangeNPCTrades(NPCLogic npcLogic)
    {
        #region Clear Existing Buttons
        for (int i = 0; i < tradeButtons.Count; i++)
        {
            Destroy(tradeButtons[i]);
        }
        tradeButtons.Clear();
        #endregion

        foreach (GameObject trade in npcLogic.npcBase.tradeIngredients)
        {
            GameObject _tradeButton = Instantiate(p_tradeButton, tradeParent);
            _tradeButton.GetComponent<TradeButtonScript>().activeNPC = activeNPC;
            tradeButtons.Add(_tradeButton);
        }

        for (int i = 0; i < tradeButtons.Count; i++)
        {
            TradeButtonScript logic = tradeButtons[i].GetComponent<TradeButtonScript>();

            logic.amount.text = npcLogic.npcBase.costAmounts[i].ToString();
            logic._amount = npcLogic.npcBase.costAmounts[i];

            logic.forage.GetComponent<Image>().sprite = npcLogic.npcBase.costIngredients[i].GetComponent<SpriteRenderer>().sprite;
            logic.forage.GetComponent<Image>().color = npcLogic.npcBase.costIngredients[i].GetComponent<SpriteRenderer>().color;
            logic.forage = npcLogic.npcBase.costIngredients[i];
            logic.forageType = logic.forage.GetComponent<IngredientLogic>().ingredient;

            logic.trade.GetComponent<Image>().sprite = npcLogic.npcBase.tradeIngredients[i].GetComponent<SpriteRenderer>().sprite;
            logic.trade.GetComponent<Image>().color = npcLogic.npcBase.tradeIngredients[i].GetComponent<SpriteRenderer>().color;
            logic.trade = npcLogic.npcBase.tradeIngredients[i];
            logic.tradeType = logic.trade.GetComponent<IngredientLogic>().ingredient;

        }
    }
    public void OpenActiveAction()
    {
        switch (npcAction)
        {
            case NPCActions.Interact:
                interactUI.SetActive(true);
                converseUI.SetActive(false);
                tradeUI.SetActive(false);
                giveUI.SetActive(false);
                break;
            case NPCActions.Converse:
                interactUI.SetActive(false);
                converseUI.SetActive(true);
                tradeUI.SetActive(false);
                giveUI.SetActive(false);
                break;
            case NPCActions.Trade:
                interactUI.SetActive(false);
                converseUI.SetActive(false);
                tradeUI.SetActive(true);
                giveUI.SetActive(false);
                break;
            case NPCActions.Give:
                interactUI.SetActive(false);
                converseUI.SetActive(false);
                tradeUI.SetActive(false);
                giveUI.SetActive(true);
                break;
        }
    }
    public void ChangeAction(NPCActions action)
    {
        npcAction = action;

        switch (action)
        {
            case NPCActions.Interact:
                interactUI.SetActive(true);
                converseUI.SetActive(false);
                tradeUI.SetActive(false);
                giveUI.SetActive(false);
                UIManager.Instance.inventoryUI.SetActive(false);
                break;
            case NPCActions.Converse:
                interactUI.SetActive(false);
                converseUI.SetActive(true);
                tradeUI.SetActive(false);
                giveUI.SetActive(false);
                UIManager.Instance.inventoryUI.SetActive(false);
                break;
            case NPCActions.Trade:
                interactUI.SetActive(false);
                converseUI.SetActive(false);
                tradeUI.SetActive(true);
                giveUI.SetActive(false);
                UIManager.Instance.inventoryUI.SetActive(true);
                break;
            case NPCActions.Give:
                interactUI.SetActive(false);
                converseUI.SetActive(false);
                tradeUI.SetActive(false);
                giveUI.SetActive(true);
                UIManager.Instance.inventoryUI.SetActive(true);
                break;
        }
    }

    #region BUTTON EVENTS

    public void Interaction() => ChangeAction(NPCActions.Interact);
    public void Conversation() => ChangeAction(NPCActions.Converse);
    public void Trade() => ChangeAction(NPCActions.Trade);
    public void Giving() => ChangeAction(NPCActions.Give);
    public void Leave() => UIManager.Instance.NPCInteractionUI(true);
    public void Return()
    {
        interactUI.SetActive(true);
        converseUI.SetActive(false);
        tradeUI.SetActive(false);
        giveUI.SetActive(false);
        UIManager.Instance.inventoryUI.SetActive(false);
    }
    #endregion

    #region NPC ACTION, IP & DP FUNCTIONS
    public void NPCChange(GameObject activeNPC, NPCActions action, int ipIncrease, int dpIncrease)
    {
        SO_NPCData npcData = activeNPC.GetComponent<NPCLogic>().npcData;
        npcAction = action;
        npcData.interactionPoints += ipIncrease;
        npcData.dialoguePoints += dpIncrease;
    }
    public void NPCChange(GameObject activeNPC, NPCActions action, int ipIncrease)
    {
        npcAction = action;
        activeNPC.GetComponent<NPCLogic>().npcData.interactionPoints += ipIncrease;
    }
    public void IPChange(GameObject activeNPC, int ipIncrease) => activeNPC.GetComponent<NPCLogic>().npcData.interactionPoints += ipIncrease;
    public void DPChange(GameObject activeNPC, int dpIncrease) => activeNPC.GetComponent<NPCLogic>().npcData.dialoguePoints += dpIncrease;
    #endregion
}

public enum NPCActions
{
    Interact,
    Converse,
    Trade,
    Give
}

