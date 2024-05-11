using UnityEngine;

public class JoystickMovement : JoystickHandler
{
	[SerializeField] private CharacterMovement _characterMovement;

	private void FixedUpdate()
	{
		_characterMovement.MoveCharacter();

		if (InputVector.x != 0 || InputVector.y != 0)
		{
			_characterMovement.RotateCharacter(new Vector3(InputVector.x, InputVector.y,0));		
		}
		else
		{
			_characterMovement.RotateCharacter(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0));
		}
	}
}
