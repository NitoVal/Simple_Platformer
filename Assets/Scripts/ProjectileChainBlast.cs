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
    const int MAX_CONNECTED_BOMBS = 3;
    public float explosionRadius;
    public float detectionRadius;
    private float _lifetime;
    
    private Vector2 _newCenter;
    public Rigidbody2D rb;
    
    void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
