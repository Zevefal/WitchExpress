using UnityEngine;

public class PointerMovement : MonoBehaviour
{
	private float _maxOffset = 1f;
	private float _moveSpeed = 2f;

	private Vector3 _startPosition;
	private Vector3 _endPosition;
	private Vector3 _target;

	private int _moveDirection = 1;

	private void Start()
	{
		_startPosition = transform.position;
		_endPosition = transform.position - new Vector3(0, _maxOffset, 0);
	}

	void Update()
	{
		if (_moveDirection == 1)
		{
			_target = _endPosition;
		}
		else if (_moveDirection == -1)
		{
			_target = _startPosition;
		}

		transform.position = Vector3.MoveTowards(transform.position, _target, _moveSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, _target) <= 0.1f)
		{
			_moveDirection *= -1;
		}
	}
}
