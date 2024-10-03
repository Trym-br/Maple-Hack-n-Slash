using System.Collections;
using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;

public class RootrunnerController : MonoBehaviour
{
    public float scoreWorth = 0f;
    public GameObject hedge;
    private NavMeshSurface navMeshSurface;
    private Animator _animator;
    private NavMeshAgent _agent;
    private Rigidbody2D _rb2d;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        // StartCoroutine(CheckForComponent());
        navMeshSurface = NavMeshController.global_navMeshSurface;
        _animator = this.GetComponent<Animator>();
        _agent = this.GetComponent<NavMeshAgent>();
        _rb2d = this.GetComponent<Rigidbody2D>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private IEnumerator CheckForComponent()
    {
        yield return new WaitForSeconds(1);
        navMeshSurface = GameObject.Find("NavMesh").GetComponent<NavMeshSurface>();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _rb2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void RootrunnerDeath()
    {
        // _agent.enabled = false;
        _agent.isStopped = true;
        _rb2d.isKinematic = true;
        // _animator.Play("Rootrunner_Rise");
        _animator.SetBool("Dead", true);
        StartCoroutine(RiseAnimationDoneCallback());
    }
    IEnumerator RiseAnimationDoneCallback()
    {
        // Wait until the animation finishes
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length * 0.7f);
        Instantiate(hedge, transform.position, Quaternion.identity);
        navMeshSurface.BuildNavMesh();
        WaveController.EnemiesLeft -= 1; 
        PlayerController.Score += scoreWorth;
        Destroy(gameObject);
    }
}
