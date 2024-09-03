using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void GetHit(int damage)
    {
        damage = Mathf.Clamp(damage, 0, maxHP);
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Die();
        }

        Debug.Log(currentHP);
    }


    void Die()
    {
        // Handle player death
        Debug.Log("Player died");
    }
}
