using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    NavMeshAgent agent;
    EnemyCombat enemyCombat;
    void Awake()
    {
        enemyCombat = GetComponent<EnemyCombat>();
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        enemyCombat.OnAttack += OnAttack;
        enemyCombat.OnGetHit += OnGetHit;
        enemyCombat.OnDie += OnDie;
        enemyCombat.OnWalk += OnWalk;
    }

    void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

        void OnGetHit()
    {
        animator.SetTrigger("GetHit");
    }

    void OnDie()
    {
        animator.SetTrigger("Die");
    }  

    void OnWalk()
    {

    }

        void OnDisable()
    {
        enemyCombat.OnAttack -= OnAttack;
        enemyCombat.OnGetHit -= OnGetHit;
        enemyCombat.OnDie -= OnDie;
        enemyCombat.OnWalk -= OnWalk;
    }

}
