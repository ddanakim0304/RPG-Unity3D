using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    NavMeshAgent agent;
    PlayerCombat playerCombat;
    void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        playerCombat.OnSingleShot += OnSingleShot;
        playerCombat.OnBurstShot += OnBurstShot;
        playerCombat.OnDie += OnDie;
        playerCombat.OnWalk += OnWalk;
    }

    void OnSingleShot()
    {
        animator.SetTrigger("SingleShot");
    }

        void OnBurstShot()
    {
        animator.SetTrigger("BurstShot");
    }

    void OnDie()
    {
        animator.SetTrigger("Die");
    }  

    void OnWalk()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            agent.Move(movement * Time.deltaTime * agent.speed);
            animator.SetFloat("Walk", 1f); // Set to 1 when moving
        }
        else
        {
            animator.SetFloat("Walk", 0f); // Set to 0 when not moving
        }
    }

        void OnDisable()
    {
        playerCombat.OnSingleShot -= OnSingleShot;
        playerCombat.OnBurstShot -= OnBurstShot;
        playerCombat.OnDie -= OnDie;
        playerCombat.OnWalk -= OnWalk;
    }

}
