using System;
using UnityEngine;

public class GizmoDrawWireframe : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}