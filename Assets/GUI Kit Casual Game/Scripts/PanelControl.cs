using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LayerLab
{
	public class PanelControl : MonoBehaviour
	{
		private int page = 0;
		private bool isReady = false;
		[SerializeField] private List<GameObject> panels = new List<GameObject>();
		[SerializeField] private Transform _horizontalPanel;
		[SerializeField] private Transform _verticalPanel;
		[SerializeField] private Button buttonPrev;
		[SerializeField] private Button buttonNext;
		
		private Transform _panelTransform;

		private void Start()
		{
			if(Agava.WebUtility.Device.IsMobile)
			{
				_panelTransform = _verticalPanel;
			}
			else
			{
				_panelTransform = _horizontalPanel;
			}
			
			buttonPrev.onClick.AddListener(Click_Prev);
			buttonNext.onClick.AddListener(Click_Next);

			foreach (Transform panel in _panelTransform)
			{
				panels.Add(panel.gameObject);
				panel.gameObject.SetActive(false);
			}

			panels[page].SetActive(true);
			isReady = true;

			CheckControl();
		}

		void Update()
		{
			if (panels.Count <= 0 || !isReady) return;

			if (Input.GetKeyDown(KeyCode.LeftArrow))
				Click_Prev();
			else if (Input.GetKeyDown(KeyCode.RightArrow))
				Click_Next();
		}

		public void Click_Prev()
		{
			if (page <= 0 || !isReady) return;

			panels[page].SetActive(false);
			panels[page -= 1].SetActive(true);
			CheckControl();
		}

		public void Click_Next()
		{
			if (page >= panels.Count - 1) return;

			panels[page].SetActive(false);
			panels[page += 1].SetActive(true);
			CheckControl();
		}

		void SetArrowActive()
		{
			buttonPrev.gameObject.SetActive(page > 0);
			buttonNext.gameObject.SetActive(page < panels.Count - 1);
		}

		private void CheckControl()
		{
			SetArrowActive();
		}
	}
}
