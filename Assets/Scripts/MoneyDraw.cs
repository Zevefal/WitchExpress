using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDraw : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private Wallet _wallet;

    private void OnDisable()
    {
        _wallet.MoneyChanged -= SetText;
    }

    private void OnEnable()
    {
        _wallet.MoneyChanged += SetText;
    }

    private void SetText(int money)
    {
        _moneyText.text = "Money: " + money.ToString();
    }
}
