using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLemon : Projectile
{
    public Rigidbody2D rb;
    private void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
    }
}
