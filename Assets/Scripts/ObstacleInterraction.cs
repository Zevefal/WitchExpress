using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleInterraction : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitParticle;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            //Vector3 closest = player.GetComponent<BoxCollider>().ClosestPointOnBounds(player.transform.position);
            ParticleSystem particleFx = Instantiate(_hitParticle, player.transform.position, Quaternion.identity);
            particleFx.Play();
            Destroy(gameObject);
            player.TakeDamage(gameObject.GetComponent<Obstacle>().ObstacleDamage);
        }
    }
}
