using UnityEngine;

namespace LayerLab
{
    public class Panel : MonoBehaviour
    {
        [SerializeField] private GameObject[] _otherPanels;

        public void OnEnable()
        {
            for (int i = 0; i < _otherPanels.Length; i++) _otherPanels[i].SetActive(true);
        }

        public void OnDisable()
        {
            for (int i = 0; i < _otherPanels.Length; i++) _otherPanels[i].SetActive(false);
        }
    }
}
