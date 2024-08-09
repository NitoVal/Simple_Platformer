using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProjectileBouncyBall : Projectile
{
    public float lifeTime;
    private float _addedDamage = 0;
        
    public Rigidbody2D rb;
    private Vector2 _lastVelocity;
    void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
        _addedDamage = affiliatedWeapon.Damage;
    }
    
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            gameObject.SetActive(false);
        _lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _addedDamage += 2f;
        if (Mathf.Abs(transform.rotation.eulerAngles.z % 180) == 0)
        {
            //Get a random angle
            float randomAngle = Random.Range(-60f, 60f);
            
            float speed = _lastVelocity.magnitude;
            Vector2 direction = Vector2.Reflect(_lastVelocity.normalized, other.contacts[0].normal);
            
            direction = Quaternion.Euler(0, 0, randomAngle) * direction;
            rb.velocity = direction * Mathf.Max(speed, 0f);
            
            //Set the new rotation of the projectile
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
