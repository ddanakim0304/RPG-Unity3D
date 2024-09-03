using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float size;

    public float attackRange = 2f;
    public int attackDamage = 10;

    public Player player;

    public Transform guideTransform;
    public Transform playerTransform;

    public void Update()
    {
        float distance = Vector3.Distance(guideTransform.position,playerTransform.position);

        if (distance <= attackRange)
        {
            Attack();
        }

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(guideTransform.position, size);
    }


    void Attack()
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetHit(attackDamage);
        }
    }

}