using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObstacleScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
}
