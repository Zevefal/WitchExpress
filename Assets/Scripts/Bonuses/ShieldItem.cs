using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
	private const string ShieldSound = "Shield";

	[SerializeField] private int _shieldTimeDuration;

	private Coroutine _activateShield;
	private PlayerHealth _player;

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<PlayerHealth>(out PlayerHealth player))
		{
			_player = player;
			_activateShield = StartCoroutine(ActivateShield());
			SoundHandler.Instance.PlaySound(ShieldSound);
		}
	}

	private IEnumerator ActivateShield()
	{
		_player.SetShieldOn();
		transform.SetParent(_player.transform, true);
		transform.position = _player.transform.position;

		yield return new WaitForSeconds(_shieldTimeDuration);

		_player.SetShieldOff();
		
		if (_activateShield != null)
		{
			StopCoroutine(_activateShield);
			Destroy(gameObject);
		}
	}
}
