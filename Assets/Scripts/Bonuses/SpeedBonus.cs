using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpeedBonus : MonoBehaviour
{
    private const string BrakeSound = "Brake";
    private const string BoostSound = "Boost";

    [SerializeField] private int _speedBonus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterMovement>(out CharacterMovement playerMovement))
        {
            playerMovement.StartSpeedBonus(_speedBonus);

            if (_speedBonus > 0)
            {
                SoundHandler.Instance.PlaySound(BoostSound);
            }
            else
            {
                SoundHandler.Instance.PlaySound(BrakeSound);
            }
        }
    }
}
