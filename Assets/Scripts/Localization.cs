using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

public class Localization : MonoBehaviour
{
    private const string LanguagePrefs = "Language";
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
                //PlayerPrefs.SetString(LanguagePrefs, English.ToString());
                break;
            case RussianCode:
                _localization.SetCurrentLanguage(RussianLanguage);
                //PlayerPrefs.SetString(LanguagePrefs, Russian.ToString());
                break;
            case TurkishCode:
                _localization.SetCurrentLanguage(TurkishLanguage);
                //PlayerPrefs.SetString(LanguagePrefs, Turkish.ToString());
                break;
            //default:
            //    LeanLocalization.SetCurrentLanguageAll(English.ToString());
            //    //PlayerPrefs.SetString(LanguagePrefs, English.ToString());
            //    _language = English.ToString();
            //    break;
        }
    }

    public void InitializeLanguage(string savedLanguage)
    {
        //if (PlayerPrefs.HasKey(LanguagePrefs))
        //{
        //    LeanLocalization.SetCurrentLanguageAll(SaveSystem.Instance.PlayerData.Language);
        //}
        //else
        //{
        //    ChangeLanguage();
        //}

        _localization.SetCurrentLanguage(savedLanguage);
    }
}
