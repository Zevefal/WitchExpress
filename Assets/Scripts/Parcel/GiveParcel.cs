using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveParcel : MonoBehaviour
{
    [SerializeField] private Transform _parcelPosition;
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            GameObject parcel = playerHealth.gameObject.transform.GetComponentInChildren<Parcel>().gameObject;

            parcel.transform.position = _parcelPosition.position;
            parcel.transform.rotation = Quaternion.identity;
            parcel.transform.SetParent(gameObject.transform, true);

            _wallet.AddMoney(parcel.GetComponent<Parcel>().Reward);
        }
    }
}
