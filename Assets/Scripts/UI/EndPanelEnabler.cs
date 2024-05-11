using UnityEngine;

public class EndPanelEnabler : MonoBehaviour
{
	[SerializeField] private GameObject _panel;
	[SerializeField] private GameObject[] _panelsToDisable;
	[SerializeField] private GameObject _earnedObject;
	[SerializeField] private GameObject _panelVictoryText;
	[SerializeField] private GameObject _panelDeadText;
	[SerializeField] private GameObject _videoAdButton;
	[SerializeField] private SceneHandler _sceneHandler;
	[SerializeField] private PlayerHealth _playerHealth;
	[SerializeField] private Wallet _wallet;

	private void OnEnable()
	{
		_playerHealth.IsDead += ShowDeadPanel;
		FinishWallInterraction.Finished += ShowVictoryPanel;
	}

	private void OnDisable()
	{
		_playerHealth.IsDead -= ShowDeadPanel;
		FinishWallInterraction.Finished -= ShowVictoryPanel;
	}

	private void ShowVictoryPanel()
	{
		if (!_panel.activeSelf)
		{
			DisablePanels();
			_panel.SetActive(true);
			_earnedObject.SetActive(true);
			_panelVictoryText.SetActive(true);

			if (_wallet.RewardMoney > 0)
			{
				_videoAdButton.SetActive(true);
			}
		}

		_sceneHandler.SetPause();
	}

	private void ShowDeadPanel()
	{
		if (!_panel.activeSelf)
		{
			DisablePanels();
			_panel.SetActive(true);
			_panelDeadText.SetActive(true);

			if (_wallet.RewardMoney > 0)
			{
				_videoAdButton.SetActive(true);
			}
		}

		_sceneHandler.SetPause();
	}
	
	private void DisablePanels()
	{
		foreach (GameObject panel in _panelsToDisable)
		{
			panel.SetActive(false);
		}
	}
}
