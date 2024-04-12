using System;
using UnityEngine;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

public class Wallet : MonoBehaviour
{
	private const string MoneyPrefs = "Money";

	[SerializeField] private YandexLeaderboard _leaderboard;
	[SerializeField] private SaveLoadManager _saveLoadManager;

	private int _money;
	
	public int Money => _money;

	public static Action<int> MoneyChanged;

	public void AddMoney(int moneyCount)
	{
		if (moneyCount >= 0)
		{
			_money += moneyCount;
		}

		MoneyChanged?.Invoke(_money);
		SetPlayerRecord(_money);
		_saveLoadManager.SaveGame();
		PlayerPrefs.SetInt(MoneyPrefs, _money);
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
}
