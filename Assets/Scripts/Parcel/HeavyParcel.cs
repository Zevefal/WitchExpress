using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyParcel : Parcel
{
    private int _minMoneyReward = 5;
    private int _maxMoneyReward = 50;
    private int _minSpeedReduction = 30;
    private int _maxSpeedReduction = 50;

    public override void CreateParcel()
    {
        MoneyReward = Random.Range(_minMoneyReward, _maxMoneyReward);
        ParcelType = HeavyTypeName;
        SpeedReductionPercent = Random.Range(_minSpeedReduction, _maxSpeedReduction);
    }
}
