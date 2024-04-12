using System;
using UnityEngine;

public class GiveParcel : MonoBehaviour
{
	[SerializeField] private Transform _parcelPosition;
	
	public static Action<int> IsPlayerRewarded;

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<Wallet>(out Wallet playerWallet))
		{
			Parcel parcel = playerWallet.gameObject.transform.GetComponentInChildren<Parcel>();

			parcel.gameObject.transform.position = _parcelPosition.position;
			parcel.gameObject.transform.rotation = Quaternion.identity;
			parcel.gameObject.transform.SetParent(gameObject.transform, true);
			playerWallet.AddMoney(parcel.Reward);
			IsPlayerRewarded?.Invoke(parcel.Reward);
		}
	}
}
