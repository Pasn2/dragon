using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawLine : MonoBehaviour
{
    [SerializeField] float distance;
    private void OnDrawGizmos() {
        Gizmos.DrawRay(transform.position,transform.forward * distance);
    }
}
