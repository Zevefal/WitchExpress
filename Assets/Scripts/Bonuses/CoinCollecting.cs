using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CoinCollecting : MonoBehaviour
{
	const string CoinSound = "Coin";

	[SerializeField] private int _coinValue = 1;

	public static Action<int> CoinCollected;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent<Wallet>(out Wallet wallet))
		{
			SoundHandler.Instance.PlaySound(CoinSound);
			wallet.AddMoney(_coinValue);
			CoinCollected?.Invoke(_coinValue);
			Destroy(gameObject);
		}
	}
}
