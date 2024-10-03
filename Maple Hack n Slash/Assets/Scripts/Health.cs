using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Health : MonoBehaviour
{
    public float maxHp = 1f;
    public float hp = 1f;
    private SpriteRenderer sr;
    
    [SerializeField] private UnityEvent TakeDamageExtra;
    [SerializeField] private UnityEvent DieExtra;

    // S or m
    public float invisTime = 0.3f;
    [SerializeField] private float invisTimer = 0f;

    void Start()
    {
        hp = maxHp;
        sr = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        if (invisTimer <= 0f)
        {
            invisTimer = invisTime;   
            hp -= damage;
            if (hp <= 0f)
            {
                Die();
            }
            else
            {
                HurtAnim();
                TakeDamageExtra?.Invoke();
            }
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
    public void HurtAnim()
    {
        StartCoroutine(HurtAnimation());
    }
    IEnumerator HurtAnimation()
    {
        // bro same
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
}