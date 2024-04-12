using System.Collections;
using UnityEngine;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;


public class CharacterMovement : MonoBehaviour
{
	private const string SpeedPowerUp = "Speed";
	private const string MobilityPowerUp = "Mobility";

	[SerializeField] private int _speed;
	[SerializeField] private float _rotateSpeed;

	private Coroutine _bonusSpeedCoroutine;
	private float XRotation = 0;
	private float YRotation = 0;
	private int _maxAngle = 40;
	private int _minAngle = -40;
	private float _minHorizontalPosition = -17f;
	private float _maxHorizontalPosition = 17f;
	private float _minVerticalPosition = 1f;
	private float _maxVerticalPosition = 10f;


	public int Speed => _speed;
	public float Mobility => _rotateSpeed;

	public void SetMobility(int mobility)
	{
		_rotateSpeed -= (int)(_rotateSpeed * (mobility / 100f));
	}

	public void SetSpeed(int speed)
	{
		_speed -= (int)(_speed * (speed / 100f));
	}

	public void MoveCharacter()
	{
		transform.Translate(Vector3.forward * _speed * Time.deltaTime);
		LimitPosition();
	}

	public void RotateCharacter(Vector3 moveDirection)
	{
		float XaxisRotation = -moveDirection.x * _rotateSpeed * Time.deltaTime;
		float YaxisRotation = moveDirection.y * _rotateSpeed * Time.deltaTime;

		XRotation -= XaxisRotation;
		YRotation -= YaxisRotation;
		XRotation = Mathf.Clamp(XRotation, _minAngle, _maxAngle);
		YRotation = Mathf.Clamp(YRotation, _minAngle, _maxAngle);
		transform.localRotation = Quaternion.Euler(YRotation, XRotation, 0f);
	}

	public void PowerUp(string name, int count)
	{
		if (name == MobilityPowerUp)
		{
			PowerUpMobility(count);
		}
		else if (name == SpeedPowerUp)
		{
			PowerUpSpeed(count);
		}
	}

	public void StartSpeedBonus(int bonusCount)
	{
		_bonusSpeedCoroutine = StartCoroutine(SpeedBonus(bonusCount));
	}

	public void InitiliazeMovementParametrs(int savedSpeed, float savedMobility)
	{
		_speed = savedSpeed;
		_rotateSpeed = savedMobility;
	}

	private void LimitPosition()
	{
		float horizontalPosition = Mathf.Clamp(transform.position.x, _minHorizontalPosition, _maxHorizontalPosition);
		float verticalPostion = Mathf.Clamp(transform.position.y, _minVerticalPosition, _maxVerticalPosition);
		transform.position = new Vector3(horizontalPosition, verticalPostion, transform.position.z);
	}

	private void PowerUpMobility(int count)
	{
		_rotateSpeed += count;
	}

	private void PowerUpSpeed(int count)
	{
		_speed += count;
	}

	private IEnumerator SpeedBonus(int bonusCount)
	{
		int startingSpeed = _speed;
		int timeOfAction = 3;

		_speed += bonusCount;

		if (_speed <= 0)
		{
			_speed = 0;
		}

		yield return new WaitForSeconds(timeOfAction);

		_speed = startingSpeed;
		StopSpeedBonus();
	}

	private void StopSpeedBonus()
	{
		StopCoroutine(_bonusSpeedCoroutine);
		_bonusSpeedCoroutine = null;
	}
}
