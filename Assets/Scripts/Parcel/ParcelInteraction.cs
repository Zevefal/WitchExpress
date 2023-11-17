using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelInteraction : MonoBehaviour
{
    private const string ParcelPlaceName = "ParcelPoint";

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.TryGetComponent<PreciousParcel>(out PreciousParcel preciousParcel))
        {
            if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
            {
                PlaseToPlayer(playerHealth.gameObject);
                playerHealth.SetPlayerHealth(preciousParcel.LifeReduction);
            }

        }
        else if (gameObject.TryGetComponent<BigParcel>(out BigParcel bigParcel))
        {
            if (other.TryGetComponent<CharacterMovement>(out CharacterMovement characterMovement))
            {
                PlaseToPlayer(characterMovement.gameObject);
                characterMovement.SetMobility(bigParcel.MobilityReduction);
            }
        }
        else if (gameObject.TryGetComponent<HeavyParcel>(out HeavyParcel heavyParcel))
        {
            if (other.TryGetComponent<CharacterMovement>(out CharacterMovement characterMovement))
            {
                PlaseToPlayer(characterMovement.gameObject);
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
    }
}
