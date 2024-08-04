using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSingularityCannon : ProjectileBase
{
    public Rigidbody2D rb;
    public float duration;
    void Awake()
    {
        rb.AddForce(transform.right * affiliatedWeapon.ProjectileSpeed);
    }
    
    void Update()
    {
        duration -= Time.deltaTime;
        
        if (duration <= 0)
            gameObject.SetActive(false);
    }

     void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            other.gameObject.GetComponent<EnemyBase>().TakeDamage(affiliatedWeapon.Damage);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
    }
}
