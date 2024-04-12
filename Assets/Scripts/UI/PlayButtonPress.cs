using UnityEngine;
using Agava.WebUtility;

public class PlayButtonPress : MonoBehaviour
{
    private const string UiSound = "Ui";

    [SerializeField] private PlayerEnergy _energy;
    [SerializeField] private GameObject[] _interfaces;
    [SerializeField] private GameObject _jostick;
    [SerializeField] private SceneHandler _sceneHandler;
    [SerializeField] private SaveLoadManager _saveLoadManager;


    public void PressStart()
    {
        SoundHandler.Instance.PlaySound(UiSound);

        SetObjectsActivity();
        _sceneHandler.StartGame();
        _saveLoadManager.SaveGame();
    }

    private void SetObjectsActivity()
    {
        if (Device.IsMobile)
        {
            _jostick.SetActive(true);
        }

        foreach (GameObject ui in _interfaces)
        {
            if (ui.activeSelf == true)
            {
                ui.SetActive(false);
            }
        }
    }
}
