using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Obstacle[] _obstacleTemplates;

    private int _maxSpawnRate = 101;
    private int _minSpawnRate = 0;
    private int _spawnChance = 80;

    private void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            if (_spawnChance > Random.Range(_minSpawnRate, _maxSpawnRate))
            {
                Obstacle newObstacle = Instantiate(_obstacleTemplates[Random.Range(0, _obstacleTemplates.Length)], transform);
                newObstacle.transform.position = _spawnPoints[i].position;
            }
        }
    }
}
