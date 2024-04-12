using TMPro;
using UnityEngine;

public class EndPanelEnabler: MonoBehaviour
{
	[SerializeField] private GameObject _panel;
	[SerializeField] private GameObject _earnedObject;
	[SerializeField] private GameObject _panelVictoryText;
	[SerializeField] private GameObject _panelDeadText;
	[SerializeField] private SceneHandler _sceneHandler;
	[SerializeField] private PlayerHealth _playerHealth;
	[SerializeField] private TMP_Text _earnedText;

	private int _reawardCount = 0;
	
	public int RewardCount => _reawardCount;

	private void OnEnable()
	{
		_playerHealth.IsDead += ShowDeadPanel;
		FinishWallInterraction.Finished += ShowVictoryPanel;
		//ParcelInteraction.IsPicked += SetRewardText;
		GiveParcel.IsPlayerRewarded += IncreaseReward;
		//Wallet.MoneyAdded += IncreaseReward;
		CoinCollecting.CoinCollected += IncreaseReward;
	}

	private void OnDisable()
	{
		_playerHealth.IsDead -= ShowDeadPanel;
		FinishWallInterraction.Finished -= ShowVictoryPanel;
		//ParcelInteraction.IsPicked -= SetRewardText;
		GiveParcel.IsPlayerRewarded -= IncreaseReward;
		// Wallet.MoneyAdded -= IncreaseReward;
		CoinCollecting.CoinCollected -= IncreaseReward;
	}

	private void ShowVictoryPanel()
	{
		if (!_panel.activeSelf)
		{
			_panel.SetActive(true);
			_earnedObject.SetActive(true);
			SetRewardText();
			_panelVictoryText.SetActive(true);
		}

		_sceneHandler.SetPause();
	}

	private void ShowDeadPanel()
	{
		if (!_panel.activeSelf)
		{
			_panel.SetActive(true);
			_panelDeadText.SetActive(true);
			SetRewardText();
		}

		_sceneHandler.SetPause();
	}

	private void SetRewardText(/*int reward*/)
	{
		_earnedText.text = _reawardCount.ToString();
		Debug.Log("�������� REWARD � ������" + _reawardCount.ToString());
	}

	private void IncreaseReward(int count)
	{
		_reawardCount += count;
		Debug.Log("�������� REWARD" + _reawardCount.ToString());
	}
}
