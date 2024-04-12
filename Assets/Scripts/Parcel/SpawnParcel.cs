using UnityEngine;

public class SpawnParcel : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private UnityEngine.GameObject[] _parcelTemplates;

    private void Start()
    {
        foreach(Transform point in _spawnPoints)
        {
            Instantiate(_parcelTemplates[Random.Range(0,_parcelTemplates.Length)], point.position, Quaternion.identity);
        }
    }
}
