using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    [SerializeField] private string _name;

    public void PlaySound()
    {
        SoundHandler.Instance.PlaySound(_name);
    }
}
