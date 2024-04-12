using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private const string VerticalMove = "VerticalMove";
    private const string HorizotalMove = "HorizotalMove";

    [SerializeField] int _obstacleDamage;
    [SerializeField] bool _isMoving;
    [SerializeField] bool _isRotating;
    [SerializeField] int _rotateSpeed;

    private Vector3 _pointLeftPosition;
    private Vector3 _pointRightPosition;
    private Vector3 _pointUpPosition;
    private Vector3 _pointDownPosition;
    private Vector3 _target;

    private int _moveDirection = 1;
    private float _distanceOffset = 0.2f;
    private float _moveSpeed;
    private float _minNegativeValue = -1;
    private float _minPositiveValue = 1;
    private float _minRandomOffset = -5f;
    private float _maxRandomOffset = 10f;
    private float _minSpeed = 0.5f;
    private float _maxSpeed = 2f;
    private string _directionName;
    private List<string> _directions = new List<string>() { VerticalMove, HorizotalMove };
    
    public int ObstacleDamage => _obstacleDamage;

    private void Start()
    {
        if(_isMoving)
        {
            SetDirection();
            _moveSpeed = Random.Range(_minSpeed, _maxSpeed);
        }
    }

    private void Update()
    {
        if(_isRotating)
        {
            RotateObject();
        }

        MoveObject();
    }

    private void SetDirection()
    {
        _directionName = _directions[Random.Range(0, _directions.Count)];

        if (_directionName == VerticalMove)
        {
            _pointUpPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(_minPositiveValue, _maxRandomOffset), transform.position.z);
            _pointDownPosition = new Vector3(transform.position.x, transform.position.y - Random.Range(_minNegativeValue, _minRandomOffset), transform.position.z);
        }
        else if (_directionName == HorizotalMove)
        {
            _pointLeftPosition = new Vector3(transform.position.x - Random.Range(_minNegativeValue, _minRandomOffset), transform.position.y, transform.position.z);
            _pointRightPosition = new Vector3(transform.position.x + Random.Range(_minPositiveValue, _maxRandomOffset), transform.position.y, transform.position.z);
        }
    }

    private void RotateObject()
    {
        transform.Rotate(0, Time.deltaTime * _rotateSpeed, 0, Space.Self);
    }

    private void MoveObject()
    {
        _target = SetTarget();

        transform.position = Vector3.Lerp(transform.position, _target, _moveSpeed * Time.deltaTime);

        float distance = (_target - (Vector3)transform.position).magnitude;

        if (distance <= _distanceOffset)
        {
            _moveDirection *= -1;
        }
    }

    private Vector3 SetTarget()
    {
        if (_directionName == HorizotalMove)
        {
            if (_moveDirection == 1)
            {
                return _pointRightPosition;
            }
            else
            {
                return _pointLeftPosition;
            }
        }
        else
        {
            if (_moveDirection == 1)
            {
                return _pointUpPosition;
            }
            else
            {
                return _pointDownPosition;
            }
        }
    }
}
