using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject[] _chunkTemplates;
    [SerializeField] private GameObject _firstChunk;
    [SerializeField] private GameObject _lastChunk;
    [SerializeField] private int _chunksCount;

    private List<Chunk> _spawnedChunks = new List<Chunk>();

    private void Start()
    {
        _spawnedChunks.Add(_firstChunk.GetComponent<Chunk>());

        for (int i = 0; i < _chunksCount; i++)
        {
            SpawnChunk();
        }

        GameObject lastChunk = Instantiate(_lastChunk);
        lastChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].GetComponent<Chunk>().EndPoint.position - lastChunk.GetComponent<Chunk>().BeginPoint.localPosition;
    }

    private void SpawnChunk()
    {
        GameObject newChunk = Instantiate(_chunkTemplates[Random.Range(0, _chunkTemplates.Length)], gameObject.transform);
        newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].GetComponent<Chunk>().EndPoint.position - newChunk.GetComponent<Chunk>().BeginPoint.localPosition;
        _spawnedChunks.Add(newChunk.GetComponent<Chunk>());
    }
}
