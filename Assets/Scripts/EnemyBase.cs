using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyBase : MonoBehaviour
{
    [Header("Base properties")]
    public float maxHp;
    public float currentHp;
    public float damage;
    private bool _bIsDead;
        
    public List<GameObject> dropList;
    
    private float _invulnerabilityTimer;
    public float invulnerabilityDuration;
    
    private Coroutine _invulnerabilityCoroutine;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    
    public LayerMask targetMask;
    void Awake()
    {
        currentHp = maxHp;
    }

    protected virtual void Update()
    {
    }

    public void TakeDamage(float dmg)
    {
        if (_invulnerabilityTimer <= 0)
        {
            currentHp -= dmg;
            if (currentHp <= 0 && !_bIsDead)
            {
                Die();
                return;
            }
            _invulnerabilityTimer = invulnerabilityDuration;
        }
                            
        if (_invulnerabilityCoroutine != null)
            StopCoroutine(_invulnerabilityCoroutine);
        if (!_bIsDead)
            _invulnerabilityCoroutine = StartCoroutine(HandleInvulnerability());

    }

    private IEnumerator HandleInvulnerability()
    {
        while (_invulnerabilityTimer > 0)
        {
            _invulnerabilityTimer -= Time.deltaTime;
            spriteRenderer.color = _invulnerabilityTimer > 0 ? Color.gray : Color.red;
            yield return null; 
        }
    }
    private void Die()
    {
        gameObject.SetActive(false);
        int randIndex = Random.Range(0, dropList.Count - 1);
        _bIsDead = true;
        if (dropList[randIndex] != null)
            Instantiate(dropList[randIndex], transform.position, transform.rotation);
    }
}
