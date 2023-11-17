using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreciousParcel : Parcel
{
    private int _minMoneyReward = 10;
    private int _maxMoneyReward = 70;
    private int _minHPReduction = 30;
    private int _maxHPReduction = 50;

    public override void CreateParcel()
    {
        MoneyReward = Random.Range(_minMoneyReward, _maxMoneyReward);
        ParcelType = PreciousTypeName;
        LifeReductionPercent = Random.Range(_minHPReduction, _maxHPReduction);
    }
}
