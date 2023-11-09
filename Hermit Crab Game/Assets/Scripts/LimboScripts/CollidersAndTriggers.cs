using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersAndTriggers : MonoBehaviour
{
    [SerializeField] private bool house;
    [SerializeField] private bool mossel;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (house && !mossel) LimboSceneManager.Instance.touchingHouse = true;

        if (!house && mossel) LimboSceneManager.Instance.touchingCollider = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (house && !mossel) LimboSceneManager.Instance.touchingHouse = false;

        if (!house && mossel) LimboSceneManager.Instance.touchingCollider = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (house && !mossel) LimboSceneManager.Instance.onDoorStep = true;

        if (!house && mossel) LimboSceneManager.Instance.onTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (house && !mossel) LimboSceneManager.Instance.onDoorStep = false;

        if (!house && mossel) LimboSceneManager.Instance.onTrigger = false;

    }
}
