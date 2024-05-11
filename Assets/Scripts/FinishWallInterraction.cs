using System;
using UnityEngine;
using UnityEngine.Events;

public class FinishWallInterraction : MonoBehaviour
{
	private const string VictorySound = "Victory";

	public static event Action Finished;
	public bool IsFinished {get; private set;} = false;
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
		{
			SoundHandler.Instance.PlaySound(VictorySound);
			Finished?.Invoke();
			IsFinished = true;
		}
	}
}
