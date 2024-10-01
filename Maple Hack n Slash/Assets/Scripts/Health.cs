using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent TakeDamageExtra;
    [SerializeField] private UnityEvent DieExtra;
    
    public float maxHp = 1f;
    public float hp = 1f;

    // S or m
    public float invisTime = 0.3f;
    [SerializeField] private float invisTimer = 0f;

    void Start()
    {
        hp = maxHp;
    }

    void TakeDamage(float damage)
    {
        if (invisTimer <= 0f)
        {
            invisTimer = invisTime;   
            hp -= damage;
            if (hp <= 0f)
            {
                Die();
            }
            TakeDamageExtra?.Invoke();
        }
    }

    private void Update()
    {
       invisTimer -= Time.deltaTime; 
    }

    void Die()
    {
        DieExtra?.Invoke();
    }
}