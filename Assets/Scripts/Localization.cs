using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

public class Localization : MonoBehaviour
{
    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";
    private const string RussianLanguage = "Russian";
    private const string EnglishLanguage = "English";
    private const string TurkishLanguage = "Turkish";

    [SerializeField] private LeanLocalization _localization;

    private string _language;

    public string Language => _language;

    private void Awake()
    {
        ChangeLanguage();
    }

    private void ChangeLanguage()
    {
        string enviromentLanguage = YandexGamesSdk.Environment.i18n.lang;

        switch (enviromentLanguage)
        {
            case EnglishCode:
                _localization.SetCurrentLanguage(EnglishLanguage);
                break;
            case RussianCode:
                _localization.SetCurrentLanguage(RussianLanguage);
                break;
            case TurkishCode:
                _localization.SetCurrentLanguage(TurkishLanguage);
                break;
        }
    }
}
