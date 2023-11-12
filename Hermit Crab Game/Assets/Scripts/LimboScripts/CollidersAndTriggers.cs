using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersAndTriggers : MonoBehaviour
{
    [SerializeField] private bool house;
    [SerializeField] private bool mossel;
    [SerializeField] private bool inHouse;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (house && !mossel) LimboSceneManager.Instance.touchingHouse = true;

        if (!house && mossel) LimboSceneManager.Instance.touchingCollider = true;

        if (inHouse) LimboSceneManager.Instance.touchWall = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (house && !mossel) LimboSceneManager.Instance.touchingHouse = false;

        if (!house && mossel) LimboSceneManager.Instance.touchingCollider = false;

        if (inHouse) LimboSceneManager.Instance.touchWall = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (house && !mossel) LimboSceneManager.Instance.onDoorStep = true;

        if (!house && mossel) LimboSceneManager.Instance.onTrigger = true;

        if (inHouse) LimboSceneManager.Instance.doorEnter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (house && !mossel) LimboSceneManager.Instance.onDoorStep = false;

        if (!house && mossel) LimboSceneManager.Instance.onTrigger = false;

        if (inHouse) LimboSceneManager.Instance.doorEnter = false;
    }
}
