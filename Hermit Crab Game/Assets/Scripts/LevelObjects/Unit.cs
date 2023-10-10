using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;

    public int damage;

    public int currentHP;
    public int maxHP;

    public GameObject wallParticle;
    
    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            if (gameObject.CompareTag("chunk"))
            {
                WallBreak();
            }
        }
    }

    void WallBreak()
    {
        //GameObject particle = Instantiate(wallParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
