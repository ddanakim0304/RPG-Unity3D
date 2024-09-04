using UnityEngine;

public class BulletDestoryer : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy this game object
            Destroy(gameObject);
        }
    }
}
