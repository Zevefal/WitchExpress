using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigParcel : Parcel
{
    private int _minMoneyReward = 5;
    private int _maxMoneyReward = 50;
    private int _minMobilityReduction = 30;
    private int _maxMobilityReduction = 50;

    public override void CreateParcel()
    {
        MoneyReward = Random.Range(_minMoneyReward, _maxMoneyReward);
        ParcelType = BigTypeName;
        MobilityReductionPercent = Random.Range(_minMobilityReduction, _maxMobilityReduction);
    }
}
