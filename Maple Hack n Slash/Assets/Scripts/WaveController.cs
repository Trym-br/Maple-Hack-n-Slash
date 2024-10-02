using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class WaveController : MonoBehaviour
{
    public Vector3[] spawnpoints;

    // waves             1                  2                  3                     4                 5   Boss
    // int[][] waves = { { 1, 1, 1, 1, 1 }, { 1, 1, 1, 2, 2 }, { 1, 2, 2, 1, 3, 3 }, { 3, 3, 2, 2, 2}, {}, {} };
    int[][] waves = 
    {
        new[] { 1, 1, 1, 1, 1},
        new[] { 1, 1, 1, 2, 2 },
        new[] { 1, 1, 2, 2, 3, 3},
        new[] { 2, 2, 2, 3, 3, 3},
        new[] { 2, 3, 3, 2, 2, 3, 2},
        new[] { 4, 3, 2, 2, 2 },
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void startWave(int waveIndex)
    {
        for (int i = 0; i < waves[waveIndex].Length; i++)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
