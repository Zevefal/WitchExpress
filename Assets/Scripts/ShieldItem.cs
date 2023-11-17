using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    [SerializeField] int _shieldTimeDuration;

    private Coroutine _activateShield;
    private PlayerHealth _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            _player = player;
            _activateShield = StartCoroutine(ActivateShield());
        }
    }

    private IEnumerator ActivateShield()
    {
        _player.SetShieldOn();
        transform.SetParent(_player.transform, true);
        transform.position = _player.transform.position;

        yield return new WaitForSeconds(_shieldTimeDuration);

        _player.SetShieldOff();
        StopCoroutine(_activateShield);
        Destroy(gameObject);
        _activateShield = null;
    }
}
