using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    private const string SpeedPowerUp = "Speed";
    private const string MobilityPowerUp = "Mobility";

    [SerializeField] private int _speed;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;

    private Coroutine _bonusSpeedCoroutine;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetMobility(int mobility)
    {
        _rotateSpeed -= (int)(_rotateSpeed * (mobility / 100f));
    }

    public void SetSpeed(int speed)
    {
        _speed -= (int)(_speed * (speed / 100f));
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        //_rigidbody.AddRelativeForce(Vector3.forward*_speed);
        //_rigidbody.velocity = transform.forward * _speed;
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void RotateCharacter(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            transform.Rotate(0.0f, moveDirection.x * _rotateSpeed * Time.deltaTime, 0.0f, Space.World);
            transform.Rotate(-moveDirection.y * _rotateSpeed * Time.deltaTime, 0.0f, 0.0f);
        }

        if (transform.rotation.eulerAngles.z != 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
        }
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
