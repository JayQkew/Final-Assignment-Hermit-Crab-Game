using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLogic : MonoBehaviour
{
    [Header("Unit Info")]
    public ObjectType objectType;
    public GameObject ingredient;

    [Header("Breakable Object")]
    [SerializeField] private int currentHP;
    [SerializeField] private int maxHP;

    //public GameObject wallParticle;

    private void Start()
    {
        switch (objectType)
        {
            case ObjectType.Shake:
                break;
            case ObjectType.Break:
                currentHP = maxHP;
                break;
        }
    }

    public void Interact()
    {
        switch (objectType)
        {
            case ObjectType.Open: 
                break;
            case ObjectType.Shake:
                Shake();
                break;
            case ObjectType.Break:
                TakeHit();
                break;
            case ObjectType.Dig:
                break;
        }
    }

    private void TakeHit() // always just do 1 damage (focus not on combat)
    {
        currentHP -= 1;

        if (currentHP <= 0)
        {
            DestroyItem();
        }
    }

    private void Shake()
    {
        if (ingredient != null)
        {
            Debug.Log("Theres an Item here !!!");
        }
    }

    void DestroyItem()
    {
        //GameObject particle = Instantiate(wallParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

public enum ObjectType
{
    Open,
    Shake,
    Break,
    Dig
}
