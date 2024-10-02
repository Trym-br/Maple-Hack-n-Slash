using NavMeshPlus.Components;
using UnityEngine;

public class RootrunnerController : MonoBehaviour
{
    public GameObject hedge;
    public NavMeshSurface navMeshSurface;
    public void RootrunnerDeath()
    {
        Instantiate(hedge, transform.position, Quaternion.identity);
        navMeshSurface.BuildNavMesh();
        Destroy(gameObject);
    }
}
