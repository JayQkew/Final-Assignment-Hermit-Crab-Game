using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueScript : MonoBehaviour
{
    public TextAsset dialogue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) Debug.Log(dialogue.text);
    }
}
