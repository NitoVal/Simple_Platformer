using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGroundChaser : Projectile
{
    public Rigidbody2D rb;
    private bool _isTouchingGround;
    private void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
    }

    private void Update()
    {
        if (_isTouchingGround)
            rb.gravityScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            _isTouchingGround = true;
    }
}
