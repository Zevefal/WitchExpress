using UnityEngine;
using UnityEngine.Events;

public class FinishWallInterraction : MonoBehaviour
{
    private const string VictorySound = "Victory";

    public static event UnityAction Finished;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            SoundHandler.Instance.PlaySound(VictorySound);
            Finished?.Invoke();
        }
    }
}
