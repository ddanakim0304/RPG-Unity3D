using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController_legacy : MonoBehaviour
{
    public enum State {Idle, Walk, SingleShot, BurstShot, Die};
    public State state = State.Idle;
    public int hp=100;
    NavMeshAgent agent;
    public Camera cam;
    public LayerMask movementMask;
    public Animator animator;
    public Image damageScreen;

    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
        animator = GetComponent<Animator>();
        damageScreen.enabled = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit by enemy");
            hp -= 10;
            damageScreen.enabled = true;
            if (hp <= 0)
            {
                animator.SetTrigger("Die");
            }
            Invoke("DisableDamageScreen", 0.1f);
        }
    }

    private void DisableDamageScreen()
    {
        damageScreen.enabled = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("SingleShot");
        }

        if(Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("BurstShot");
        }

        if(Input.GetMouseButtonDown(2))
        {
            animator.SetTrigger("Die");
        }

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
}