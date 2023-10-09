using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Attack animation
        anim.SetTrigger("Attack");

        Collider2D[] hitObject = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, wallLayer);

        foreach(Collider2D objectHit in hitObject)
        {
            Unit unit = objectHit.GetComponent<Unit>();

            if(unit != null)
            {
                if (unit.gameObject.CompareTag("chunk"))
                    Debug.Log("Fuck");
                unit.TakeDamage(5);
            }
        }
    }
}
