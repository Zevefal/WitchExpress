using Agava.YandexGames;
using UnityEngine;

public class LeaderboardShower : MonoBehaviour
{
    [SerializeField] private GameObject _authorizePanel;
    [SerializeField] private GameObject _leaderboardPanel;

    public void ShowLeaderboard()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            _leaderboardPanel.SetActive(true);
            _leaderboardPanel.GetComponent<YandexLeaderboard>().Fill();
        }

        if (PlayerAccount.IsAuthorized == false)
        {
            _authorizePanel.SetActive(true);
        }
    }
}
