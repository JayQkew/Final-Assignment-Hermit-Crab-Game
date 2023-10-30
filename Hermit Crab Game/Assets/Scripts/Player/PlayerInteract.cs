using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInteract : MonoBehaviour
{
    public static PlayerInteract Instance { get; private set; }

    public Animator anim;

    [Header("Mouse Ray")]
    [SerializeField] private float rayRadius;
    [SerializeField] private LayerMask interactableObject;

    [Header("Interaction")]
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRange = 0.5f;
    [SerializeField] private GameObject[] hitObjects;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        MouseHit();
        InteractionCircle();

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");

            foreach (var hitObject in hitObjects)
            {
                if (MouseHit() == hitObject && hitObject.GetComponent<IngredientLogic>() != null)
                {
                    PlayerInventory.Instance.SortIngredient(hitObject);
                    hitObject.gameObject.SetActive(false);
                    InventoryLogic.Instance.DataToVisual();
                }
                else if (MouseHit() == hitObject && MouseHit().tag == "interactableObject") hitObject.GetComponent<ObjectLogic>().Interact();
                else if (MouseHit() == hitObject && MouseHit().tag == "npc") hitObject.GetComponent<NPCLogic>().Interact();

            }
        }
    }

    private void InteractionCircle()
    {
        Collider2D[] _hitObjects = Physics2D.OverlapCircleAll(interactionPoint.position, interactionRange, interactableObject);
        hitObjects = new GameObject[_hitObjects.Length];

        for (int i = 0; i < _hitObjects.Length; i++)
        {
            hitObjects[i] = _hitObjects[i].gameObject;
        }
    }

    private Vector2 MousePos()
    {
        Vector2 screenPos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(screenPos);
    }

    private GameObject MouseHit()
    {
        Vector2 screenPos = Input.mousePosition;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(screenPos);

        Ray ray = new Ray(mousePos, Vector3.forward);

        if (!Physics2D.OverlapCircle(mousePos, rayRadius, interactableObject)) return null;
        else return Physics2D.OverlapCircle(mousePos, rayRadius, interactableObject).gameObject;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(interactionPoint.position, interactionRange);
    //    Gizmos.DrawWireSphere(MousePos(), rayRadius);
    //}

}
