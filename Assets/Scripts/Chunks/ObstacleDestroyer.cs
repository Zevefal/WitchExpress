using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
	void OnCollisionEnter(Collision collider)
	{
		if(collider.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
		{
			Debug.Log("Asfadgfsadgfsadgfadsgsadg");
			Destroy(obstacle.gameObject);
		}
	}
}
