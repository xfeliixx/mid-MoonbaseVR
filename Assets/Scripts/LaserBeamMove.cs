using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamMove : MonoBehaviour
{
    public float thrust = 10f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //using fixed update with physics.
    void FixedUpdate()
    {
        rb.velocity = transform.forward * thrust;

        Destroy(gameObject, 2f);
    }
}
