using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShooterEnemy : EnemyBase
{ 
    [Header("Shooter Properties")]
    public float speed;
    public float fireCooldown;
    public float detectionRadius;
    
    public GameObject projectile;
    public Transform firepoint;
    
    protected override void Update()
    {
        base.Update();
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectionRadius, targetMask);
        if (hit)
        {
            //Stop the enemy movement
            rb.velocity = Vector2.zero;

            //Rotate the firepoint
            Vector2 dir = hit.transform.position - firepoint.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            firepoint.rotation = Quaternion.Euler(0f, 0f, angle);
            
            //Fire at the player
            if (fireCooldown <= 0)
            {
                Instantiate(projectile, firepoint.position, firepoint.rotation);
                fireCooldown = 1f;
            }
        }
        else
            rb.velocity = new Vector2(Vector2.left.x * speed, rb.velocity.y);

        fireCooldown -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
