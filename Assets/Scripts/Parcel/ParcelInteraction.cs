using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParcelInteraction : MonoBehaviour
{
    private const string ParcelPlaceName = "ParcelPoint";
    private const string PickupSound = "Pick";

    public static event UnityAction<Parcel> IsPicked;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.TryGetComponent<PreciousParcel>(out PreciousParcel preciousParcel))
        {
            if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
            {
                PlaseToPlayer(playerHealth.gameObject);
                IsPicked?.Invoke(preciousParcel);
                playerHealth.DebaffPlayerHealth(preciousParcel.LifeReduction);
            }

        }
        else if (gameObject.TryGetComponent<BigParcel>(out BigParcel bigParcel))
        {
            if (other.TryGetComponent<CharacterMovement>(out CharacterMovement characterMovement))
            {
                PlaseToPlayer(characterMovement.gameObject);
                IsPicked?.Invoke(bigParcel);
                characterMovement.SetMobility(bigParcel.MobilityReduction);
            }
        }
        else if (gameObject.TryGetComponent<HeavyParcel>(out HeavyParcel heavyParcel))
        {
            if (other.TryGetComponent<CharacterMovement>(out CharacterMovement characterMovement))
            {
                PlaseToPlayer(characterMovement.gameObject);
                IsPicked?.Invoke(heavyParcel);
                characterMovement.SetSpeed(heavyParcel.SpeedReduction);
            }
        }
    }

    private void PlaseToPlayer(UnityEngine.GameObject player)
    {
        Transform parcelPosition = player.transform.Find(ParcelPlaceName);
        transform.SetParent(parcelPosition, true);
        transform.position = parcelPosition.position;
        transform.rotation = player.transform.rotation;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        SoundHandler.Instance.PlaySound(PickupSound);
    }
}
