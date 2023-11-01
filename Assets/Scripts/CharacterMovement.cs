using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private float _rotateSpeed;
    
    private Rigidbody _rigidbody;

    private Coroutine _bonusSpeedCoroutine;

    public void MoveCharacter(Vector3 moveDirection)
    {
        _rigidbody.velocity = transform.forward * _speed;
    }

    public void RotateCharacter(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward,moveDirection)>0)
        {
            transform.Rotate(0.0f, moveDirection.x*_rotateSpeed*Time.deltaTime, 0.0f, Space.World);
            transform.Rotate(-moveDirection.y * _rotateSpeed*Time.deltaTime, 0.0f, 0.0f);
        }
    }

    public void StartSpeedBonus(int bonusCount)
    {
        _bonusSpeedCoroutine = StartCoroutine(SpeedBonus(bonusCount));
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private IEnumerator SpeedBonus(int bonusCount)
    {
        int startingSpeed = _speed;
        int timeOfAction = 3;

        _speed += bonusCount;

        if(_speed <= 0)
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
        {
            StopCoroutine(_bonusSpeedCoroutine);
            _bonusSpeedCoroutine = null;
        }
    }
}
