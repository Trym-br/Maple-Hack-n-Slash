using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManual : MonoBehaviour
{
    public Transform target;
    private NavMeshPath path;
    private float elapsed = 0.0f;
    public float updateFrequency = 0.2f;
    public float moveSpeed = 10.0f;
    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        path = new NavMeshPath();
        elapsed = 0.0f;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Update the way to the goal every second.
        elapsed += Time.deltaTime;
        if (elapsed > updateFrequency)
        {
            elapsed = 0.0f;
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
        }

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }
        
        // Move towards the goal
        // _rigidbody2D.linearVelocityX = 4;
        
        
    }

    private void FixedUpdate()
    {
        // Debug.Log("Corners" + path.corners.Length);
        Vector3 targetPosition = path.corners[1]; // Replace with your target
        Debug.Log("TP:" + targetPosition + ", P:" + transform.position);
        Vector3 direction = (targetPosition - transform.position).normalized;
        // Debug.Log("D * S = LV: " + direction + " * " + speed + " = " + direction * speed);
        Debug.Log("Direction: " + direction);
        _rigidbody2D.linearVelocity = direction * moveSpeed;
    }
}
