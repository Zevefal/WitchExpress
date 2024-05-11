using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
		Load();
	}

	private void OnEnable()
	{
		FinishWallInterraction.Finished += Save;
	}

	private void OnDisable()
	{
		FinishWallInterraction.Finished -= Save;
	}

	public void DeleteSave()
	{
		PlayerPrefs.DeleteAll();

		_wallet.SetMoney(50);
		_health.SetPlayerHealth(10);
		_characterMovement.InitiliazeMovementParametrs(8, 28);
		_settingsPanel.ChangeVolume(PlayerInfo.Volume);
		_slider.value = PlayerInfo.Volume;
		_settingsPanel.ToggleMusic(PlayerInfo.Music);
		_settingsPanel.ToggleSound(PlayerInfo.Sound);

		Save();
	}

	public void Save()
	{
		StartCoroutine(SaveDataCoroutine());
	}

	public void Load()
	{
		StartCoroutine(LoadGameCouroutine());
	}

	public void SaveGameData()
	{
		PlayerData playerData = new PlayerData()
		{
			Money = _wallet.Money,
			TotalMoney = _wallet.TotalEarnedMoney,
			Health = _health.Health,
			Speed = _characterMovement.StartedSpeed,
			Mobility = _characterMovement.StartedRotation,
			Volume = _settingsPanel.Volume,
			Music = _settingsPanel.MusicToggle,
			Sound = _settingsPanel.SoundToggle,
			MobilityLevel = _upgrade.GetPowerCount(MobilityPowerUp),
			SpeedLevel = _upgrade.GetPowerCount(SpeedPowerUp),
			HealthLevel = _upgrade.GetPowerCount(HealthPowerUp),
		};

		string jsonString = JsonUtility.ToJson(playerData);

		PlayerAccount.SetCloudSaveData(jsonString);
		PlayerPrefs.SetString(SaveKey, jsonString);
	}

	public void LoadGameData()
	{
		PlayerAccount.GetCloudSaveData(OnSuccessLoad, OnErrorLoad);
	}

	private void OnSuccessLoad(string json)
	{
		PlayerInfo = JsonUtility.FromJson<PlayerData>(json);
		AddToPlayerData();
	}

	private void OnErrorLoad(string message)
	{
		if (PlayerPrefs.HasKey(SaveKey))
		{
			string json = PlayerPrefs.GetString(SaveKey);
			PlayerInfo = JsonUtility.FromJson<PlayerData>(json);
			AddToPlayerData();
		}
		else
		{
			AddDefaultParametrs();
		}
	}

	private void AddToPlayerData()
	{
		_wallet.SetMoney(PlayerInfo.Money);
		_wallet.SetTotalMoney(PlayerInfo.TotalMoney);
		_health.SetPlayerHealth(PlayerInfo.Health);
		_characterMovement.InitiliazeMovementParametrs(PlayerInfo.Speed, PlayerInfo.Mobility);
		_settingsPanel.ChangeVolume(PlayerInfo.Volume);
		_slider.value = PlayerInfo.Volume;
		_settingsPanel.ToggleMusic(PlayerInfo.Music);
		_settingsPanel.ToggleSound(PlayerInfo.Sound);
		PlayerPrefs.SetInt(MobilityPowerUp, PlayerInfo.MobilityLevel);
		PlayerPrefs.SetInt(SpeedPowerUp, PlayerInfo.SpeedLevel);
		PlayerPrefs.SetInt(HealthPowerUp, PlayerInfo.HealthLevel);
	}

	private IEnumerator AutoSave()
	{
		yield return new WaitForSeconds(_saveTime);
		StartCoroutine(AutoSave());
	}

	public IEnumerator SaveDataCoroutine()
	{
		SaveGameData();
		yield return new WaitForEndOfFrame();
	}

	public IEnumerator LoadGameCouroutine()
	{
		LoadGameData();
		yield return new WaitForEndOfFrame();
	}

	private void AddDefaultParametrs()
	{
		_wallet.SetMoney(50);
		_health.SetPlayerHealth(10);
		_characterMovement.InitiliazeMovementParametrs(8, 28);
		PlayerPrefs.SetInt(MobilityPowerUp, 1);
		PlayerPrefs.SetInt(SpeedPowerUp, 1);
		PlayerPrefs.SetInt(HealthPowerUp, 1);
	}
}