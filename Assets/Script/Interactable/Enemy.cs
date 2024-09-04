using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float size;

    public int hp = 100;
    public float speed = 2.0f;
    public float attackRange = 2f;
    public int attackDamage = 10;

    public Player player;

    public Transform guideTransform;
    public Transform playerTransform;
    private Animator animator;

    public GameObject gameController; // Reference to the GameManager or the object with EnemyCounter script


    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    public void Update()
    {
        MoveTowardsPlayer();
        float distance = Vector3.Distance(guideTransform.position, playerTransform.position);

        if (distance <= attackRange)
        {
            Attack();
        }
    }

    void MoveTowardsPlayer()
    {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            float distance = Vector3.Distance(playerTransform.position, transform.position);

            if (distance > 1.0f) // Adjust this value as needed
            {
                transform.position += direction * speed * Time.deltaTime;
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }

            // Rotate to face the player
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
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
        else if (other.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("GetHit");
            
            hp -= 10;
            if (hp <= 0)
            {
                animator.SetTrigger("Die");
                StartCoroutine(DestroyAfterAnimation());
            }
        }
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    void OnDestroy()
    {
        if (gameController != null)
        {
            EnemyCounter counter = gameController.GetComponent<EnemyCounter>();
            if (counter != null)
            {
                counter.IncrementEnemyCount();
            }
        }
    }
}