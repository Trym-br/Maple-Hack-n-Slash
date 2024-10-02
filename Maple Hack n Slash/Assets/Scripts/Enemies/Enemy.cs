using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Collider2D playerCollider;
    NavMeshAgent agent;
    
    Rigidbody2D rb;
    NavMeshAgent ag;

    void Start () {
        rb = GetComponent<Rigidbody2D>();   
        ag = GetComponent<NavMeshAgent>();

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