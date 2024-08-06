using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Launches a bomb that can attaches to nearby bombs.
/// when the bomb is connected to 1 or 3 other bombs the blast point changes, the radius expands and the damage increases
/// </summary>
public class ProjectileChainBlast : Projectile
{
    const int MaxChainCount = 3;
    public float explosionRadius;
    public float detectionRadius;
    private float _lifetime;
    
    private Vector2 _newCenter;
    public LayerMask bombMask;
    
    public Rigidbody2D rb;
    void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
    }

    private void Update()
    {
        Collider2D[] nearbyBombs = Physics2D.OverlapCircleAll(transform.position,detectionRadius,bombMask);
        foreach (Collider2D bomb in nearbyBombs)
        {

        }
    }

    private void OnDrawGizmos()
    {

    }
}
