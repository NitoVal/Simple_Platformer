using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHomingMissile : ProjectileBase
{
    public Rigidbody2D rb;
    public Transform enemyPosition;
    public LayerMask enemyMask;
    void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
    }

    private void Update()
    {
        if (!enemyPosition)
        {
            Collider2D closestEnemy = Physics2D.OverlapCircle(transform.position, 10f, enemyMask);
            if (closestEnemy)
                enemyPosition = closestEnemy.transform;
        }
        else
        {
            //move toward enemy
            transform.position = Vector2.MoveTowards(transform.position,enemyPosition.position, affiliatedWeapon.ProjectileSpeed / 30 * Time.deltaTime);
            
            //Rotate towards enemy
            Vector2 target = enemyPosition.position;
            target.x -= transform.position.x;
            target.y -= transform.position.y;
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0,0, angle));
        }
            
    }
}
