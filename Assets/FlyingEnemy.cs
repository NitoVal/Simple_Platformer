using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : EnemyBase
{
    public float detectionRadius;

    public Transform target;
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectionRadius, targetMask);
        if (hit)
        {
            target = hit.gameObject.transform;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, .1f);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
