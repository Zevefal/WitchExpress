using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Obstacle[] _obstacleTemplates;

    private void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        for(int i = 0; i < _obstacleTemplates.Length; i++)
        {
            Obstacle newObstacle = Instantiate(_obstacleTemplates[Random.Range(0, _obstacleTemplates.Length)]);
            newObstacle.transform.parent = transform;
            newObstacle.transform.position = _spawnPoints[i].position;
        }
    }
}
