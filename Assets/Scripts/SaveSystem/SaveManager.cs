using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class SaveManager : MonoBehaviour
{
	public static SaveManager Instance {get; private set;}
	
	private PlayerData1 _playerData;
	
	private void Awake()
	{
		if(Instance != null)
		{
			Debug.LogError("Found more than one Data");
		}
		
		Instance = this;
	}
	
	private void Start()
	{
		LoadGame();
	}
	
	public void NewGame()
	{
		this._playerData = new PlayerData1(); 
	}
	
	public void LoadGame()
	{
		if(this._playerData == null)
		{
			NewGame();
		}
	}
	
	public void SaveGame()
	{
		
	}
	
	private void OnApplicationQuit()
	{
		SaveGame();
	}
}
