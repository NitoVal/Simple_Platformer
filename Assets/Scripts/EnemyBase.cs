using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyBase : MonoBehaviour
{
    [Header("Base properties")]
    public float maxHp;
    public float currentHp;
    public float damage; 
        
    public List<GameObject> dropList;
    
    private float _invulnerabilityTimer;
    public float invulnerabilityDuration;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    
    public LayerMask targetMask;
    void Awake()
    {
        currentHp = maxHp;
    }
    
    protected virtual void Update()
    {
        _invulnerabilityTimer -= Time.deltaTime;
        spriteRenderer.color = _invulnerabilityTimer < 0 ? Color.red : Color.gray;
    }

    public void TakeDamage(float dmg)
    {
        if (_invulnerabilityTimer <= 0)
        {
            currentHp -= dmg;
            if (currentHp <= 0)
                Die();
            _invulnerabilityTimer = invulnerabilityDuration;
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        int randIndex = Random.Range(0, dropList.Count - 1);

        if (dropList[randIndex] != null)
            Instantiate(dropList[randIndex], transform.position, transform.rotation);
    }
}
