using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _bonusesTemplates;

    private int _spawnChance = 60;
    private int _maxSpawnRate = 101;
    private int _minSpawnRate = 0;

    private void Start()
    {
        SpawnBonuses();
    }

    private void SpawnBonuses()
    {
        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            if(_spawnChance > Random.Range(_minSpawnRate, _maxSpawnRate))
            {
                GameObject spawnedBonus = Instantiate(_bonusesTemplates[Random.Range(0,_bonusesTemplates.Length)], transform);
                spawnedBonus.transform.parent = transform;
                spawnedBonus.transform.position = _spawnPoints[i].position;
            }
        }
    }
}
