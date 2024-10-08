using UnityEngine;
using UnityEngine.AI;

public class EnemyOld : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
