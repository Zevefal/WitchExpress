using System;
using UnityEngine;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

public class Wallet : MonoBehaviour
{
	private const string MoneyPrefs = "Money";

	[SerializeField] private YandexLeaderboard _leaderboard;
	[SerializeField] private SaveLoadManager _saveLoadManager;

	private int _money;
	private int _totalEarnedMoney;
	private int _rewardMoney;
	
	public int Money => _money;
	public int TotalEarnedMoney => _totalEarnedMoney;
	public int RewardMoney => _rewardMoney;

	public static Action<int> MoneyChanged;

	public void AddMoney(int moneyCount)
	{
		if (moneyCount >= 0)
		{
			_money += moneyCount;
			_totalEarnedMoney += moneyCount;
		}

		MoneyChanged?.Invoke(_money);
		SetPlayerRecord(_totalEarnedMoney);
		//_saveLoadManager.SaveGameData();
		_saveLoadManager.Save();
		PlayerPrefs.SetInt(MoneyPrefs, _money);
	}
	
	public void AddReward(int rewardCount)
	{
		_rewardMoney += rewardCount;
	}

	public void SetMoney(int savedMoney)
	{
		_money = savedMoney;

		MoneyChanged?.Invoke(_money);
	}

	public void TakeMoney(int money)
	{
		if (money <= _money)
		{
			_money -= money;
		}

		PlayerPrefs.SetInt(MoneyPrefs, _money);
		MoneyChanged?.Invoke(_money);
	}

	public void SetPlayerRecord(int record)
	{
		_leaderboard.SetPlayer(record);
	}
	
	public void SetTotalMoney(int totalMoney)
	{
		_totalEarnedMoney = totalMoney;
	}
}
