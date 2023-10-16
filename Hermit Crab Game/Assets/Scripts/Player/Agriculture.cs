using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agriculture : MonoBehaviour
{
    [SerializeField] AudioSource bushAmbiance;

    [SerializeField] private SpriteRenderer[] childRenderers;
    private float defaultAlpha = 1.0f;
    public float transparentAlpha = 0.5f;

    private void Start()
    {
        // Get all SpriteRenderer components in the children
        childRenderers = GetComponentsInChildren<SpriteRenderer>();
        bushAmbiance = GameObject.Find("Bush_Sound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(gameObject.CompareTag("Bush"))
            bushAmbiance.Play();

            Debug.Log("Fuck yeah!");

            // Player entered the collider, change the alpha of child SpriteRenderers
            SetChildRenderersAlpha(transparentAlpha);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D))
            {
                if (gameObject.CompareTag("Bush"))
                    bushAmbiance.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited the collider, reset the alpha of child SpriteRenderers
            SetChildRenderersAlpha(defaultAlpha);
        }
    }

    private void SetChildRenderersAlpha(float alpha)
    {
        // Iterate through the child SpriteRenderers and set their alpha
        foreach (SpriteRenderer childRenderer in childRenderers)
        {
            Color currentColor = childRenderer.color;
            currentColor.a = alpha;
            childRenderer.color = currentColor;
        }
    }
}
