using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCrate : MonoBehaviour
{
    public float radius;
    public LayerMask entityMask;
    
    void OnDisable()
    {
        Collider2D[] hitList = Physics2D.OverlapCircleAll(transform.position, radius, entityMask);
        if (hitList.Length > 0)
        {
            //Damage enemies and player
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
