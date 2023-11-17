using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Parcel : MonoBehaviour
{
    protected const string HeavyTypeName = "Heavy";
    protected const string BigTypeName = "Big";
    protected const string PreciousTypeName = "Precious";

    protected int MoneyReward;
    protected string ParcelType;
    protected int LifeReductionPercent;
    protected int MobilityReductionPercent;
    protected int SpeedReductionPercent;

    public int Reward => MoneyReward;
    public int LifeReduction => LifeReductionPercent;
    public int SpeedReduction => SpeedReductionPercent;
    public int MobilityReduction => MobilityReductionPercent;

    private void Start()
    {
        CreateParcel();
    }

    public abstract void CreateParcel();
}