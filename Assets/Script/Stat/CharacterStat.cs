using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterStat : MonoBehaviour
{
    int currentHP;
    public int maxHP;
    public int attack = 10;
    void OnEnable()
    {
        currentHP = maxHP;    
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            GetHit(10);
        }
    }

    void GetHit(int damage)
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
        Debug.LogFormat("{0} : DIE", transform.name);
    }
}
