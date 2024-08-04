using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLemon : ProjectileBase
{
    public Rigidbody2D rb;
    private void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
    }
}
