using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleInterraction : MonoBehaviour
{
    private const string HitSound = "Hit";

    [SerializeField] private ParticleSystem _hitParticle;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            Vector3 closest = collider.ClosestPointOnBounds(player.transform.position);
            ParticleSystem particleFx = Instantiate(_hitParticle, closest, Quaternion.identity);
            particleFx.Play();
            SoundHandler.Instance.PlaySound(HitSound);
            Destroy(gameObject);
            player.TakeDamage(gameObject.GetComponent<Obstacle>().ObstacleDamage);
        }
    }
}
