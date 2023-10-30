using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    [SerializeField] private SO_NPCData npcData;

    public NPCBase npcBase;

    public void Interact()
    {
        NPCActionLogic.Instance.npcAction = NPCActions.Interact; //this for now, will change when interactions become more indepth
        UIManager.Instance.NPCInteractionUI(false);
        NPCActionLogic.Instance.PersonaliseUI(this);
    }
}

