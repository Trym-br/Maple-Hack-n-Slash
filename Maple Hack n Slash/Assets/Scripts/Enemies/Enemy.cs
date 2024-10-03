using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Enemy : MonoBehaviour
{
    Collider2D playerCollider;
    NavMeshAgent agent;

    public float scoreWorth = 0f;
    private Animator _animator;
    
    private Rigidbody2D rb;
    private NavMeshAgent ag;
    private SpriteRenderer sr;

    void Start () {
        rb = GetComponent<Rigidbody2D>();   
        ag = GetComponent<NavMeshAgent>();
        sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();
        
        // Disable agent control of the transform
        ag.updatePosition = false;
        ag.updateRotation = false;
    }
   
    void Update () {
        // Move rigibody by agent velocity and update agent position
        
        agent.SetDestination(playerCollider.ClosestPoint(transform.position));
        // agent.SetDestination(target.position);
        rb.linearVelocity = ((Vector2)ag.velocity + rb.linearVelocity)/2;
        ag.nextPosition = rb.position;
        
        _animator.SetFloat("Horizontal", rb.linearVelocity.x);
        _animator.SetFloat("Vertical", rb.linearVelocity.y);
    }


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.updatePosition = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    // private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("triggered by: " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            Attack(other);
        }
    }

    private void Attack(Collider2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(1);
        Vector3 dir = (other.gameObject.transform.position - transform.position).normalized;
        // Debug.Log("dir of knockback: " + dir);
        // other.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * 70f, ForceMode2D.Impulse);
        rb.AddForce(-dir * 150f, ForceMode2D.Impulse);
        ag.isStopped = true;
        StartCoroutine(AttackAnimationDoneCallback());
    }
    IEnumerator AttackAnimationDoneCallback()
    {
        // Wait until the animation finishes
        yield return new WaitForSeconds(1);
        ag.isStopped = false;
    }

    public void DieExtra()
    {
        ag.isStopped = true;
        rb.isKinematic = true;
        GetComponent<BoxCollider2D>().enabled = false;
        _animator.SetBool("Dead", true);
        StartCoroutine(DeathAnimationDoneCallback());
    }

    public void TakeDamageExtra()
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
    IEnumerator DeathAnimationDoneCallback()
    {
        // Wait until the animation finishes
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length * (1/0.3f));
        WaveController.EnemiesLeft -= 1;
        PlayerController.Score += scoreWorth;
        Destroy(gameObject);
    }

}