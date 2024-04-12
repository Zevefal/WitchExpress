using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] Transform _beginPoint;
    [SerializeField] Transform _endPoint;

    public Transform BeginPoint => _beginPoint;
    public Transform EndPoint => _endPoint;
}
