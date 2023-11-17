using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private int _money = 100;

    public int Money => _money;

    public UnityAction<int> MoneyChanged;

    private void Start()
    {
        MoneyChanged?.Invoke(_money);
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyChanged?.Invoke(_money);
    }

    public void TakeMoney(int money)
    {
        _money -= money;
        MoneyChanged?.Invoke(_money);
    }
}
