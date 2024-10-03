using System;
using NavMeshPlus.Components;
using UnityEngine;

public class NavMeshController : MonoBehaviour
{
    static public NavMeshSurface global_navMeshSurface;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        global_navMeshSurface = this.GetComponent<NavMeshSurface>();
    }
}
