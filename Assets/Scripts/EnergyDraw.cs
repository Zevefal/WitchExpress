using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyDraw : MonoBehaviour
{
    [SerializeField] private TMP_Text _energyText;
    [SerializeField] private PlayerEnergy _playerEnergy;

    private void Start()
    {
        _playerEnergy.EnergyChanged += SetEnergy;
        SetEnergy(_playerEnergy.Energy, _playerEnergy.MaxEnergy);
    }

    private void OnDisable()
    {
        _playerEnergy.EnergyChanged -= SetEnergy;
    }

    private void SetEnergy(int energy, int maxEnergy)
    {
        _energyText.text = energy.ToString() + "/" + maxEnergy.ToString();
    }
}
