using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBase : MonoBehaviour
{
    private float _damage = 1f;
    private float _projectileSpeed = 600f;

    private Rigidbody2D _rb;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(transform.up * _projectileSpeed);
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
