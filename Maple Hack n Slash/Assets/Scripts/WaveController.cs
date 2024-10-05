using System.Collections;
using System.Numerics;
using NavMeshPlus.Components;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class WaveController : MonoBehaviour
{
    public NavMeshSurface Nav;
    static public int EnemiesLeft = 0;
    public Transform[] spawnpoints;
    // 1 = Red Beetle
    // 2 = Lord Skully
    // 3 = Rootrunner
    // 4 = Boss
    public GameObject[] EnemyArray;
    

    // waves             1                  2                  3                     4                 5   Boss
    // int[][] waves = { { 1, 1, 1, 1, 1 }, { 1, 1, 1, 2, 2 }, { 1, 2, 2, 1, 3, 3 }, { 3, 3, 2, 2, 2}, {}, {} };
    int[][] waves = 
    {
        new[] { 1, 1, 1, 1, 1},
        new[] { 1, 1, 1, 2, 2 },
        new[] { 1, 1, 2, 2, 3, 3},
        new[] { 2, 2, 2, 3, 3, 3},
        new[] { 2, 3, 3, 2, 2, 3, 2},
        new[] { 3, 2, 2, 2, 2 },
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(startWave(0, 1));
    }

    IEnumerator startWave(int waveIndex, float delay)
    {
        EnemiesLeft = waves[waveIndex].Length;
        Debug.Log("Starting Wave: " + waveIndex);
        Transform spawnPoint;
        foreach (int enemy in waves[waveIndex])
        {
            yield return new WaitForSeconds(delay);
            Debug.Log("Spawning Enemy: " + enemy);
            spawnPoint = spawnpoints[Random.Range(0, spawnpoints.Length - 1)];
        
            Instantiate(EnemyArray[enemy-1], spawnPoint.position, Quaternion.identity);
            // PrefabUtility.InstantiatePrefab(EnemyArray[enemy - 1]);
        }
    }

    // Update is called once per frame
    private float checkForNextWaveTimer = 10f;
    private int waveIndex = 0;
    void Update()
    {
        if (checkForNextWaveTimer <= 0f)
        {
            checkForNextWaveTimer = 3f;
            Debug.Log("Enemey Count: " + EnemiesLeft);
            if (EnemiesLeft <= 0)
            {
                Nav.BuildNavMesh();
                StartCoroutine(startWave(waveIndex, 1));
                if (waveIndex <= waves.Length - 1)
                {
                    waveIndex++;
                }
                else
                {
                    waveIndex = 4;
                }
            }
        }
        else
        {
            checkForNextWaveTimer -= Time.deltaTime;
        }
    }
}
