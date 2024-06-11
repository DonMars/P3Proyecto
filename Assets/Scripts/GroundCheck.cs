using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private Transform origin;
    [SerializeField] private LayerMask groundLayers;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(CheckRay().origin,CheckRay().direction * distance);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(CheckRay(), distance, groundLayers);
    }

    public Ray CheckRay()
    {
        return new Ray(origin.position,Vector3.down);
    }
}
