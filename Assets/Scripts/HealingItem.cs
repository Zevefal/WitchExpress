using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    [SerializeField] int _healCount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.Heal(_healCount);
            Destroy(gameObject);
        }
    }
}
