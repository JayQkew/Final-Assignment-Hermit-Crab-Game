using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class ButtonSelect : MonoBehaviour
{
    private SpriteRenderer childSpriteRenderer;
    private Color originalColor;
    public Color oudtshColor;

    private void Start()
    {

        // Get the child sprite's renderer
        childSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        oudtshColor.a = 100f;
        // Store the original color
        originalColor = childSpriteRenderer.color;
    }

    private void OnMouseEnter()
    {
        LevelManager.Instance.level = true;

        if (gameObject.CompareTag("Knysna"))
        {
            // Change the child sprite's color to yellow
            childSpriteRenderer.color = Color.yellow;
            LevelManager.Instance.sceneLevel = 3;
        }

        if (gameObject.CompareTag("Plettenberg"))
        {
            // Change the child sprite's color to yellow
            childSpriteRenderer.color = Color.blue;
            LevelManager.Instance.sceneLevel = 4;
        }

        if (gameObject.CompareTag("George"))
        {
            // Change the child sprite's color to yellow
            childSpriteRenderer.color = Color.red;
            LevelManager.Instance.sceneLevel = 2;
        }

        if (gameObject.CompareTag("Mossel"))
        {
            // Change the child sprite's color to yellow
            childSpriteRenderer.color = Color.green;
            LevelManager.Instance.sceneLevel = 0;
        }

        if (gameObject.CompareTag("Oudtshoorn"))
        {
            // Change the child sprite's color to yellow
            childSpriteRenderer.color = oudtshColor;
            LevelManager.Instance.sceneLevel = 1;
        }
    }

    private void OnMouseExit()
    {
        LevelManager.Instance.level = false;

        // Change the child sprite's color back to the original color
        childSpriteRenderer.color = originalColor;
    }
}
