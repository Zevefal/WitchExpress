using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;


public class CharacterMovement : MonoBehaviour
{
	private const string SpeedPowerUp = "Speed";
	private const string MobilityPowerUp = "Mobility";

	[SerializeField] private int _speed;
	[SerializeField] private float _rotateSpeed;
	[SerializeField] private LayerMask _stopLayer;

	private Coroutine _bonusSpeedCoroutine;
	private float XRotation = 0;
	private float YRotation = 0;
	private int _maxAngle = 60;
	private int _minAngle = -60;
	private float _minHorizontalPosition = -20f;
	private float _maxHorizontalPosition = 20f;
	private float _minVerticalPosition = 1f;
	private float _maxVerticalPosition = 24f;
	private float _detectionDistance = 4f;

	public int StartedSpeed { get; private set; }
	public float StartedRotation { get; private set; }
	public float Mobility => _rotateSpeed;

	private Rigidbody _rigidbody;

	private void Start()
	{
		StartedSpeed = _speed;
		StartedRotation = _rotateSpeed;
		_rigidbody = gameObject.GetComponent<Rigidbody>();
	}

	public void SetDebaffMobility(int mobility)
	{
		_rotateSpeed -= (int)(_rotateSpeed * (mobility / 100f));
	}

	public void SetDebaffSpeed(int speed)
	{
		_speed -= (int)(_speed * (speed / 100f));
	}

	public void MoveCharacter()
	{
		if (IsObstacleInFront() == false)
		{
			_rigidbody.velocity = transform.forward * _speed;
		}
		else
		{
			_rigidbody.MovePosition(_rigidbody.position);
		}

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
		if (_bonusSpeedCoroutine == null)
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
		StartedRotation = _rotateSpeed;
	}

	private void PowerUpSpeed(int count)
	{
		_speed += count;
		StartedSpeed = _speed;
	}

	private bool IsObstacleInFront()
	{
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		Debug.DrawRay(ray.origin, ray.direction * _detectionDistance, Color.red);

		if (Physics.Raycast(ray, out hit, _detectionDistance, _stopLayer))
		{
			return true;
		}
		else
		{
			return false;
		}
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
		if (_bonusSpeedCoroutine != null)
			StopCoroutine(_bonusSpeedCoroutine);

		_bonusSpeedCoroutine = null;
	}
}
