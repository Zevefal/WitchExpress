using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int _obstacleDamage;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_obstacleDamage);
        }
    }
}
