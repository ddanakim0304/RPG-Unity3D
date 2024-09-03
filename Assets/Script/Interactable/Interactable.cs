using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float size;

    public Transform guideTransform;
    public Transform playerTransform;

    public void Update()
    {
        float distance = Vector3.Distance(guideTransform.position,playerTransform.position);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(guideTransform.position, size);
    }
}
