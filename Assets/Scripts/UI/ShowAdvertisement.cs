using System;
using Agava.YandexGames;
using UnityEngine;

public class ShowAdvertisement : MonoBehaviour
{
	[SerializeField] private Wallet _wallet;
	[SerializeField] private int _rewardMultiplier = 2;

	public Action<bool> IsVideoOpen;
	public Action PlayerRewarded;

	public void ShowVideAd()
	{
		IsVideoOpen?.Invoke(true);
		VideoAd.Show(onRewardedCallback: OnVideoClosed);
	}

	public void ShowInterstitialAd()
	{
		if (_wallet.RewardMoney <= 0)
			InterstitialAd.Show();
		
		_wallet.AddMoney(_wallet.RewardMoney);
		PlayerRewarded?.Invoke();
	}

	private void OnVideoClosed()
	{
		IsVideoOpen?.Invoke(false);
		
		if (_wallet.RewardMoney >= 1)
			_wallet.AddMoney(_wallet.RewardMoney * _rewardMultiplier);
			
		PlayerRewarded?.Invoke();
	}
}
