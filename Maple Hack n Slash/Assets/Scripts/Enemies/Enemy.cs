using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Enemy : MonoBehaviour
{
    [SerializeField] Collider2D playerCollider;
    NavMeshAgent agent;

    private Animator _animator;
    
    private Rigidbody2D rb;
    private NavMeshAgent ag;

    void Start () {
        rb = GetComponent<Rigidbody2D>();   
        ag = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        
        // Disable agent control of the transform
        ag.updatePosition = false;
        ag.updateRotation = false;
    }
   
    void Update () {
        // Move rigibody by agent velocity and update agent position
        
        agent.SetDestination(playerCollider.ClosestPoint(transform.position));
        // agent.SetDestination(target.position);
        rb.linearVelocity = ag.velocity;
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
    }

    public void DieExtra()
    {
        Destroy(gameObject);
    }
}