using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : EnemyBase
{
    public float detectionRadius;

    Transform _target;
    
    protected override void Update()
    {
        base.Update();
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectionRadius, targetMask);
        if (hit)
            _target = hit.gameObject.transform;
    }

    private void FixedUpdate()
    {
        if (_target)
            transform.position = Vector2.MoveTowards(transform.position, _target.position, .05f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
