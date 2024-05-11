using TMPro;
using UnityEngine;

public class EndPanelUpdate : MonoBehaviour
{
	[SerializeField] private TMP_Text _rewardText;
	[SerializeField] private Wallet _wallet;
	
	private void OnEnable()
	{
		_rewardText.text = _wallet.RewardMoney.ToString();
	}
}
