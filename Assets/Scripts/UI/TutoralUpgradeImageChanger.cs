
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

public class TutoralUpgradeImageChanger : MonoBehaviour
{
	private const string EnglishCode = "en";
	private const string RussianCode = "ru";
	private const string TurkishCode = "tr";
	
	[SerializeField] private Image _upgradeSprite;
	[SerializeField] private Sprite _englishSprite;
	[SerializeField] private Sprite _russianSprite;
	[SerializeField] private Sprite _turkishSprite;

	private void Start()
	{
		string enviromentLanguage = YandexGamesSdk.Environment.i18n.lang;

		switch (enviromentLanguage)
		{
			case EnglishCode:
				_upgradeSprite.sprite = _englishSprite;
				break;
			case RussianCode:
				_upgradeSprite.sprite = _russianSprite;
				break;
			case TurkishCode:
				_upgradeSprite.sprite = _turkishSprite;
				break;
		}
	}
}
