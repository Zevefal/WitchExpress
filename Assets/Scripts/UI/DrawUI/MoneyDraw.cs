using TMPro;
using UnityEngine;

public class MoneyDraw : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    private void OnDisable()
    {
        Wallet.MoneyChanged -= SetText;
    }

    private void OnEnable()
    {
        Wallet.MoneyChanged += SetText;
    }

    private void SetText(int money)
    {
        _moneyText.text = money.ToString();
    }
}
