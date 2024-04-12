using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CoinCollecting : MonoBehaviour
{
    [SerializeField] private int _coinValue = 1;

    public static Action<int> CoinCollected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Wallet>(out Wallet wallet))
        {
            wallet.AddMoney(_coinValue);
            CoinCollected?.Invoke(_coinValue);
            Destroy(gameObject);
        }
    }
}
