using UnityEngine;

public class TutorialOrientationChanger : MonoBehaviour
{
	[SerializeField] private GameObject _verticalPanels;
	[SerializeField] private GameObject _horizontalPanels;
	
	private void Start()
	{
		if(Agava.WebUtility.Device.IsMobile)
		{
			_horizontalPanels.SetActive(false);
			_verticalPanels.SetActive(true);
		}
	}
}
