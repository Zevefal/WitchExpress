using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    [SerializeField] int _shieldTimeDuration;

    private Coroutine _activateShield;
    private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            _player = player;
            _activateShield = StartCoroutine(ActivateShield());
        }
    }

    private IEnumerator ActivateShield()
    {
        _player.SetShield(true);

        yield return new WaitForSeconds(_shieldTimeDuration);

        _player.SetShield(false);

        if (_activateShield != null)
        {
            StopCoroutine(_activateShield);
            _activateShield = null;
        }
    }
}
