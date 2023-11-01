using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpeedBonus : MonoBehaviour
{
    [SerializeField] private int _speedBonus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterMovement>(out CharacterMovement playerMovement)) 
        {
            playerMovement.StartSpeedBonus(_speedBonus);
        }
    }
}
