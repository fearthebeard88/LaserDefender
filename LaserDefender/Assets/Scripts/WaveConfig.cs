using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]

public class WaveConfig : ScriptableObject
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public GameObject pathPrefab;
    [SerializeField] public float timeBetweenSpawns = 0.5f;
    [SerializeField] public float spawnRandomFactor = 0.3f;
    [SerializeField] public int numberOfEnemies = 5;
    [SerializeField] public float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return this.enemyPrefab;}
    public GameObject GetPathPrefab() { return this.pathPrefab;}
    public float GetTimeBetweenSpawns() { return this.timeBetweenSpawns;}
    public int GetNumberOfEnemies() { return this.numberOfEnemies;}
    public float GetMoveSpeed() { return this.moveSpeed;}
}
