using Agava.YandexGames;
using UnityEngine;

public class LeaderboardAuthorization : MonoBehaviour
{
    public void PlayerAuthorization()
    {
        PlayerAccount.Authorize();
    }
}
