//using System;
//using UnityEngine;
//using Agava.YandexGames;
//using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
//using System.Collections;
//using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;

//public class SaveSystem : MonoBehaviour
//{
//    private const string PathName = "/save.dat";
//    private const string MoneyPrefs = "Money";
//    private const string HealthPrefs = "Health";
//    private const string SpeedPrefs = "Speed";
//    private const string MobilityPrefs = "Mobility";
//    private const string EnergyPrefs = "Energy";
//    private const string LanguagePrefs = "Language";
//    private const string VolumePrefs = "Volume";
//    private const string MusicPrefs = "Music";
//    private const string SliderValuePrefs = "SliderVolume";

//    private int _defaultMoney = 50;
//    private int _defaultMobility = 25;
//    private int _defaultSpeed = 5;
//    private int _defaultHealth = 10;
//    private int _defaultEnergy = 50;
//    private int _defaultVolume = 1;
//    private bool _defaultMusic = true;
//    private bool _defaultIsSaved = false;
//    private string _defaultLanguage = "En";

//    [SerializeField] private PlayerHealth _health;
//    [SerializeField] private Wallet _wallet;
//    [SerializeField] private PlayerEnergy _playerEnergy;
//    [SerializeField] private CharacterMovement _movement;
//    [SerializeField] private SettingsPanel _settings;
//    [SerializeField] private Localization _localization;

//    private float _saveTime = 10f;
//    private bool isSaved = false;

//    //private Wallet _wallet;
//    //private PlayerEnergy _playerEnergy;

//    //public static SaveSystem Instance;

//    //public PlayerData PlayerData;

//    //private void Awake()
//    //{
//    //    if (Instance == null)
//    //    {
//    //        transform.parent = null;
//    //        //DontDestroyOnLoad(gameObject);
//    //        Instance = this;
//    //    }
//    //    else
//    //    {
//    //        Destroy(gameObject);
//    //    };

//    //    LoadFromCloud();

//    //    if (PlayerData._isSaved == false)
//    //    {
//    //        PlayerData = new PlayerData();
//    //        PlayerData.SavePlayerParametrs(_defaultMoney, _defaultMobility, _defaultSpeed, _defaultHealth, _defaultEnergy, _defaultVolume, DateTime.Now, _defaultLanguage, _defaultMusic);
//    //        AddParametrsToPlayer();
//    //    }
//    //    else
//    //    {
//    //        AddParametrsToPlayer();
//    //    }
//    //}

//    private void Start()
//    {
//        SceneHandler.IsRestarted += LoadFromCloud;
//        SceneHandler.IsRestarted += AddParametrsToPlayer;
//        //StartCoroutine(SaveTimer());
//    }

//    private void OnDisable()
//    {
//        SceneHandler.IsRestarted -= LoadFromCloud;
//        SceneHandler.IsRestarted -= AddParametrsToPlayer;
//    }

//    public void Save()
//    {
//        //PlayerData.SavePlayerParametrs(PlayerPrefs.GetInt(MoneyPrefs), PlayerPrefs.GetFloat(MobilityPrefs), PlayerPrefs.GetInt(SpeedPrefs), PlayerPrefs.GetInt(HealthPrefs), PlayerPrefs.GetInt(EnergyPrefs), PlayerPrefs.GetInt(VolumePrefs), DateTime.UtcNow, PlayerPrefs.GetString(LanguagePrefs), Convert.ToBoolean(PlayerPrefs.GetInt(MusicPrefs)), PlayerPrefs.GetFloat(SliderValuePrefs));
//        //PlayerData = new PlayerData();

//        PlayerData = new PlayerData();
//        PlayerData.SavePlayerParametrs(_wallet.Money, _movement.Mobility, _movement.Speed, _health.Health, _playerEnergy.Energy, _settings.Volume, DateTime.UtcNow, _localization.Language, _settings.MusicToggle);
//        string jsonString = JsonUtility.ToJson(PlayerData);
//        PlayerAccount.SetCloudSaveData(jsonString);

//        Debug.Log("Ñîõğàíåíèå");
//        Debug.Log("Ñîõğàíèëè âîò òàêèå äàííûå");
//        Debug.Log(PlayerData.Money.ToString());
//        Debug.Log(PlayerData.Energy.ToString());
//        Debug.Log(PlayerData.Language);
//        Debug.Log("MONEY " + _wallet.Money + "Health " + _health.Health);
//    }

//    public void AddParametrsToPlayer()
//    {
//        _wallet.AddMoney(PlayerData._money);
//        _movement.InitiliazeMovementParametrs(PlayerData._speedCount, PlayerData._mobilityCount);
//        _health.SetPlayerHealth(PlayerData._healthCount);
//        _playerEnergy.AddEnergy(PlayerData._energy);
//        _settings.SetPlayerVolumeSettings(PlayerData._volume, PlayerData._music);
//        _localization.InitializeLanguage(PlayerData._language);
//    }

//    public void LoadFromCloud()
//    {
//        //PlayerAccount.GetCloudSaveData((data) => PlayerData = JsonUtility.FromJson<PlayerData>(data));
//        PlayerAccount.GetCloudSaveData((data) => Load(data));

//        //PlayerData newData = new PlayerData();
//        //PlayerData = newData;
//        Debug.Log("Çàãğóæåíû äàííûå");
//        Debug.Log(PlayerData.Money.ToString());
//        Debug.Log(PlayerData.Energy.ToString());
//        Debug.Log("ÑÎÕĞÀÍÅÍÎ ËÈ ÁÛËÎ? " + PlayerData._isSaved.ToString());
//        Debug.Log(PlayerData.Language);
//        //PlayerData = JsonUtility.FromJson<PlayerData>(_jsonString);

//        TimeSpan timePassed = DateTime.UtcNow - PlayerData.LastPlayTime;
//        int minutsPassed = (int)timePassed.TotalMinutes;
//        int EnergyCount = Mathf.Clamp(minutsPassed, 0, 7 * 24 * 60);
//        EnergyCount += minutsPassed;
//        //int totalEnergy = EnergyCount + PlayerData.Energy;
//        //_playerEnergy.AddEnergy(EnergyCount);
//        //_playerEnergy.AddEnergy(PlayerData.Energy);
//        //_wallet.AddMoney(PlayerData.Money);
//        ///
//        //if (File.Exists((Application.persistentDataPath + PathName)))
//        //{
//        //    BinaryFormatter formatter = new BinaryFormatter();
//        //    FileStream file = File.Open(Application.persistentDataPath + PathName, FileMode.Open);
//        //    PlayerData data = (PlayerData)formatter.Deserialize(file);
//        //    file.Close();
//        //    Debug.Log("Çàãğóæåíû äàííûå");
//        //    Debug.Log(data.Money.ToString());
//        //    Debug.Log(data.Energy.ToString());
//        //    Debug.Log(data.Language);

//        //    _wallet.AddMoney(data.Money);
//        //    _movement.InitiliazeMovementParametrs(data.SpeedCount, data.MobilityCount);
//        //    _health.SetPlayerHealth(data.HealthCount);
//        //    _playerEnergy.AddEnergy(data.Energy);
//        //    _settings.SetPlayerVolumeSettings(data.Volume, data.Music);
//        //    _localization.InitializeLanguage(data.Language);
//        //}
//        //else
//        //{
//        //    Debug.Log("Íå çàãğóçèëîñü");
//        //}
//    }



//    private void OnApplicationQuit()
//    {
//        Save();
//    }

//    private void Load(string data)
//    {
//        if (string.IsNullOrEmpty(data))
//        {
//            Debug.Log("Ïóñòàÿ ññûëêà íà äàííûå");
//            //PlayerData = new PlayerData();
//            //PlayerData.SavePlayerParametrs(_defaultMoney, _defaultMobility, _defaultSpeed, _defaultHealth, _defaultEnergy, _defaultVolume, DateTime.Now, _defaultLanguage, _defaultMusic);
//            //Save();
//            return;
//        }

//        Debug.Log("ÏÎËÓ×ÈËÈ ÄÀÍÍÛÅ ÈÇ ÎÁËÀÊÀ!!!!!!!!!");
//        Debug.Log("ÁÛÂØÈÅ ÄÀÍÍÛÅ ÏËÅÉÅĞ ÄÀÒÀ");
//        Debug.Log("MONEY "+PlayerData._money.ToString());
//        Debug.Log("ENERGY " + PlayerData._energy.ToString());
//        PlayerData = new PlayerData();
//        PlayerData tempData = JsonUtility.FromJson<PlayerData>(data);
//        Debug.Log("ÄÀÍÍÛÅ ÒÅÌÏ ÄÀÒÀ");
//        Debug.Log("MONEY " + tempData._money.ToString());
//        Debug.Log("ENERGY " + tempData._energy.ToString());
//        PlayerData._money = tempData._money;
//        PlayerData._energy = tempData._energy;
//        PlayerData._healthCount = tempData._healthCount;
//        PlayerData._speedCount = tempData._speedCount;
//        PlayerData._mobilityCount = tempData._mobilityCount;
//        PlayerData._music = tempData._music;
//        PlayerData._sliderValue = tempData._sliderValue;
//        PlayerData._language = tempData._language;
//        Debug.Log("ÇÀÌÅÍÅÍÍÛÅ ÄÀÍÍÛÅ ÏËÅÉÅĞ ÄÀÒÀ");
//        Debug.Log("MONEY " + PlayerData._money.ToString());
//        Debug.Log("ENERGY " + PlayerData._energy.ToString());
//    }

//    private IEnumerator SaveTimer()
//    {
//        Save();
//        yield return new WaitForSeconds(_saveTime);
//    }
//}

//[System.Serializable]
//public class PlayerData
//{
//    private int _defaultMoney = 50;
//    private int _defaultMobility = 25;
//    private int _defaultSpeed = 5;
//    private int _defaultHealth = 10;
//    private int _defaultEnergy = 50;
//    private int _defaultVolume = 1;
//    private bool _defaultMusic = true;
//    private bool _defaultIsSaved = false;
//    private string _defaultLanguage = "En";

//    public int _money;
//    public float _mobilityCount;
//    public int _speedCount;
//    public int _healthCount;
//    public int _energy;
//    public float _volume;
//    public DateTime _lastPlayTime;
//    public string _language;
//    public bool _music;
//    public float _sliderValue;
//    public bool _isSaved;

//    public int Money => _money;
//    public float MobilityCount => _mobilityCount;
//    public float Volume => _volume;
//    public int SpeedCount => _speedCount;
//    public int HealthCount => _healthCount;
//    public int Energy => _energy;
//    public string Language => _language;
//    public bool Music => _music;
//    // public float SliderValue => _sliderValue;
//    public DateTime LastPlayTime => _lastPlayTime;
//    public bool IsSaved => _isSaved;

//    //public PlayerData()
//    //{
//    //    _money = _defaultMoney;
//    //    _mobilityCount = _defaultMobility;
//    //    _speedCount = _defaultSpeed;
//    //    _healthCount = _defaultHealth;
//    //    _energy = _defaultEnergy;
//    //    _volume = _defaultVolume;
//    //    _sliderValue = _defaultVolume;
//    //    _music = _defaultMusic;
//    //    _language = _defaultLanguage;
//    //    _isSaved = _defaultIsSaved;
//    //}

//    public void SavePlayerParametrs(int Money, float Mobility, int Speed, int Health, int Energy, float Volume, DateTime Date, string Language, bool Music/*, float SliderValue*/)
//    {
//        _money = Money;
//        _mobilityCount = Mobility;
//        _speedCount = Speed;
//        _healthCount = Health;
//        _energy = Energy;
//        _volume = Volume;
//        _lastPlayTime = Date;
//        _language = Language;
//        _music = Music;
//        // _sliderValue = SliderValue;
//        _isSaved = true;
//    }

//    public void SaveMoney(int Money)
//    {
//        _money = Money;
//    }
//    //public void SavePlayerParametrs()
//    //{
//    //    _money = PlayerPrefs.GetInt(MoneyPrefs);
//    //    _mobilityCount = PlayerPrefs.GetFloat(MobilityPrefs);
//    //    _speedCount = PlayerPrefs.GetInt(SpeedPrefs);
//    //    _healthCount = PlayerPrefs.GetInt(HealthPrefs);
//    //    _energy = PlayerPrefs.GetInt(EnergyPrefs);
//    //    _volume = PlayerPrefs.GetFloat(VolumePrefs);
//    //    _lastPlayTime = DateTime.UtcNow;
//    //    _language = PlayerPrefs.GetString(LanguagePrefs);
//    //    _music =Convert.ToBoolean(PlayerPrefs.GetFloat(MusicPrefs));
//    //    _sliderValue = PlayerPrefs.GetFloat(SliderValuePrefs);
//    //    _isSaved = true;

//    //    PlayerPrefs.Save();
//    //}
//}
