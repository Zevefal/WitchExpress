using System;
using UnityEngine;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

public class Wallet : MonoBehaviour
{
	private const string MoneyPrefs = "Money";


	[SerializeField] private YandexLeaderboard _leaderboard;
	[SerializeField] private SaveLoadManager _saveLoadManager;

	private int _money;
	private int _defaultMoney = 50;

	public int Money => _money;

	public static Action<int> MoneyChanged;
	//public static Action<int> MoneyAdded;


	public void AddMoney(int moneyCount)
	{
		if (moneyCount >= 0)
		{
			_money += moneyCount;
		}

		//MoneyAdded?.Invoke(moneyCount); 
		MoneyChanged?.Invoke(_money);
		SetPlayerRecord(_money);
		_saveLoadManager.SaveGame();
		PlayerPrefs.SetInt(MoneyPrefs, _money);
		//_saveLoadManager.SaveGame();
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
		//_saveLoadManager.SaveGame();
		//_saveLoadManager.SaveGame();
	}

	public void SetPlayerRecord(int record)
	{
		_leaderboard.SetPlayer(record);
	}
}
