using System;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	private const string TutorialKey = "Tutorial";
	
	[SerializeField] private GameObject _tutorialObject;
	
	[SerializeField] private bool _tutorialEnabled;
	
	public bool TutorialEnabled => _tutorialEnabled;
	
	private void Awake()
	{
		if(PlayerPrefs.HasKey(TutorialKey))
		{
			_tutorialEnabled = Convert.ToBoolean(PlayerPrefs.GetInt(TutorialKey));
		}
	}
	
	private void Start()
	{
		if(_tutorialEnabled == true)
		{
			_tutorialObject.SetActive(true);
			PlayerPrefs.SetInt(TutorialKey, 1);
		}else
		{
			_tutorialObject.SetActive(false);
			PlayerPrefs.SetInt(TutorialKey, 0);
		}
	}
	
	public void CloseTutorial()
	{
		_tutorialObject.SetActive(false);
		_tutorialEnabled = false;
		PlayerPrefs.SetInt(TutorialKey, 0);
	}
	
	public void TutorialEnabler(bool isEnabled)
	{	
		_tutorialEnabled = isEnabled;
	}
}
