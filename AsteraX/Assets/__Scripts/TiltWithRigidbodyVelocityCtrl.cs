using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TiltWithRigidbodyVelocityCtrl : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb = null;
    [SerializeField] private int degrees = 30;
    [SerializeField] private bool tiltTowards = true;
    [SerializeField] private int previousDegrees = int.MaxValue;
    [SerializeField] private float tan = 0.0f;

    private void Reset()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //cache the tan, as its expensive
        if (!degrees.Equals(previousDegrees))
        {
            previousDegrees = degrees;
            tan = Mathf.Tan(degrees * Mathf.Deg2Rad);
        }

        Vector3 pitchDir = (tiltTowards) ? -_rb.linearVelocity : _rb.linearVelocity;
        pitchDir += Vector3.forward / tan * Constants.PLAYER_MAX_SPEED;
        transform.LookAt(transform.position + pitchDir);
    }
}