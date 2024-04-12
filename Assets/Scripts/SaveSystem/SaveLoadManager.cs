using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Threading.Tasks;

public class SaveLoadManager : MonoBehaviour
{
	private const string SaveKey = "save";
	private const string MobilityPowerUp = "Mobility";
	private const string SpeedPowerUp = "Speed";
	private const string HealthPowerUp = "Health";

	[SerializeField] private PlayerHealth _health;
	[SerializeField] private Wallet _wallet;
	[SerializeField] private CharacterMovement _characterMovement;
	[SerializeField] private SettingsPanel _settingsPanel;
	[SerializeField] private Slider _slider;
	[SerializeField] private BroomstickUpgrade _upgrade;
	[SerializeField] private Tutorial _tutorial;

	private int _saveTime = 30;
	public PlayerData PlayerInfo = new PlayerData();

	public void Awake()
	{
		LoadGame();
		StartCoroutine(AutoSave());
	}

	private void OnEnable()
	{
		FinishWallInterraction.Finished += SaveGame;
	}

	private void OnDisable()
	{
		FinishWallInterraction.Finished -= SaveGame;
		StopCoroutine(AutoSave());
	}

	public async void SaveGame()
	{
		PlayerData playerData = new PlayerData()
		{
			Money = _wallet.Money,
			Health = _health.Health,
			Speed = _characterMovement.Speed,
			Mobility = _characterMovement.Mobility,
			Volume = _settingsPanel.Volume,
			Music = _settingsPanel.MusicToggle,
			MobilityLevel = _upgrade.GetPowerCount(MobilityPowerUp),
			SpeedLevel = _upgrade.GetPowerCount(SpeedPowerUp),
			HealthLevel = _upgrade.GetPowerCount(HealthPowerUp),
			//TutorialEnable = _tutorial.TutorialEnabled
		};

		string jsonString = JsonUtility.ToJson(playerData);

		if (PlayerAccount.IsAuthorized)
		{
		   PlayerAccount.SetCloudSaveData(jsonString, OnSuccessSave, OnErrorSave);
		}
		else
		{
			PlayerPrefs.SetString(SaveKey, jsonString);
		}

		await Task.Yield();
	}

	private void OnSuccessSave()
	{
		Debug.Log("SAVE OK");
	}

	private void OnErrorSave(string message)
	{
		Debug.Log("NOT OK SAVE" + message);
	}

	public async void LoadGame()
	{
		PlayerAccount.GetCloudSaveData(OnSuccessLoad, OnErrorLoad);
		await Task.Yield();
	}

	private async void OnSuccessLoad(string json)
	{
		PlayerData TempPlayerInfo = JsonUtility.FromJson<PlayerData>(json);

		if (TempPlayerInfo != PlayerInfo)
		{
			PlayerInfo = TempPlayerInfo;
			AddToPlayerData();
		}

		await Task.Yield();
	}

	private void OnErrorLoad(string message)
	{
		if (PlayerPrefs.HasKey(SaveKey))
		{
			string json = PlayerPrefs.GetString(SaveKey);
			PlayerInfo = JsonUtility.FromJson<PlayerData>(json);
			AddToPlayerData();
		}
		else return;
	}

	private async void AddToPlayerData()
	{
		_wallet.SetMoney(PlayerInfo.Money);
		_health.SetPlayerHealth(PlayerInfo.Health);
		_characterMovement.InitiliazeMovementParametrs(PlayerInfo.Speed, PlayerInfo.Mobility);
		_settingsPanel.ChangeVolume(PlayerInfo.Volume);
		_slider.value = PlayerInfo.Volume;
		_settingsPanel.ToggleMusic(PlayerInfo.Music);
		PlayerPrefs.SetInt(MobilityPowerUp, PlayerInfo.MobilityLevel);
		PlayerPrefs.SetInt(SpeedPowerUp, PlayerInfo.SpeedLevel);
		PlayerPrefs.SetInt(HealthPowerUp, PlayerInfo.HealthLevel);
		//_tutorial.TutorialEnabler(PlayerInfo.TutorialEnable);
		// _wallet.AddMoney(50);
		// _health.SetPlayerHealth(10);
		// _playerEnergy.AddEnergy(50);
		// _characterMovement.InitiliazeMovementParametrs(5, 25);
		// _settingsPanel.ChangeVolume(1);
		// _slider.value = PlayerInfo.Volume;
		// _settingsPanel.ToggleMusic(PlayerInfo.Music);
		// PlayerPrefs.SetInt(MobilityPowerUp, 1);
		// PlayerPrefs.SetInt(SpeedPowerUp, 1);
		// PlayerPrefs.SetInt(HealthPowerUp, 1);
		// Debug.Log("Добавили HEALTH "+ PlayerInfo.Health.ToString());
		// Debug.Log("Добавили HEALTH LEVEL "+ PlayerInfo.HealthLevel.ToString());
		await Task.Yield();
	}

	private IEnumerator AutoSave()
	{
		yield return new WaitForSeconds(_saveTime);
		StartCoroutine(AutoSave());
	}

	// private int CalculateTotalEnergy()
	// {
	// 	TimeSpan timePassed = DateTime.UtcNow - PlayerInfo.LastPlayTime;
	// 	int minutsPassed = (int)timePassed.TotalMinutes;
	// 	//int EnergyCount = Mathf.Clamp(minutsPassed, 0, 7 * 24 * 60);
	// 	Debug.Log("Total energy" + minutsPassed.ToString());
	// 	//EnergyCount += minutsPassed + PlayerInfo.Energy;

	// 	return minutsPassed;
	// }
}