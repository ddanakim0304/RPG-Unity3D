using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float size;
    public Transform playerTransform;

    void Update()
    {
        float distance = Vector3.Distance(transform.position,playerTransform.position);
    }
}
