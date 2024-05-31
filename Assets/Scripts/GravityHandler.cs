using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{
    [SerializeField] private float fallSpeed;

    private GroundCheck groundCheck;
    private Rigidbody rb;
    [SerializeField]private float acceleration = 4;

    private void Start()
    {
        groundCheck = GetComponent<GroundCheck>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!groundCheck.IsGrounded())
        {
            acceleration += Time.deltaTime;
            rb.AddForce(Vector3.down * fallSpeed * acceleration,ForceMode.Acceleration);
        }
        else
        {
            acceleration = 4;
        }
    }

}
