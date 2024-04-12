using UnityEngine;

public class CoinRotating : MonoBehaviour
{
    [SerializeField] private float _rotatingSpeed = 0.5f;

    private void FixedUpdate()
    {
        transform.Rotate(0, Time.deltaTime * _rotatingSpeed, 0, Space.Self);
    }
}
