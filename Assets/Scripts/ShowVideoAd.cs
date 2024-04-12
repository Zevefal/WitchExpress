using Agava.YandexGames;
using UnityEngine;

public class ShowVideoAd : MonoBehaviour
{
	[SerializeField] private Wallet _wallet;
	[SerializeField] private EndPanelEnabler _endPanelEnabler;
	[SerializeField] private int _rewardMultiplier = 2;

	public void ShowAd()
	{
		VideoAd.Show(onCloseCallback:OnVideoClosed);
	}
	
	private void OnVideoClosed()
	{
		Time.timeScale = 0;
		_wallet.AddMoney(_endPanelEnabler.RewardCount*_rewardMultiplier);
	}
}
