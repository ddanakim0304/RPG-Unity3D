using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnPoint : MonoBehaviour
{
    // Reference to the parent GameObject
    public GameObject parentGameObject;

    // Start is called before the first frame update
    void Start()
    {
        if (parentGameObject != null)
        {
            // Set the parent of this GameObject to the specified parent GameObject
            transform.SetParent(parentGameObject.transform);
        }
    }
}