using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Animator anim;

    [Header("Interaction")]
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRange = 0.5f;
    [SerializeField] private LayerMask interactableObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InteractWithObject();
        }
    }

    void InteractWithObject()
    {
        anim.SetTrigger("Attack");

        Collider2D[] hitObject = Physics2D.OverlapCircleAll(interactionPoint.position, interactionRange, interactableObject);

        foreach(Collider2D objectHit in hitObject)
        {
            ObjectLogic unit = objectHit.GetComponent<ObjectLogic>();

            if(unit != null)
            {
                unit.Interact();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRange);
    }
}
