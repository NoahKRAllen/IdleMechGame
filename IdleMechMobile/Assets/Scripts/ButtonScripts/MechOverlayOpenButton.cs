using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class MechOverlayOpenButton : MonoBehaviour
    {
        private GameObject _overlayScreen;
        private Button _button;
        private ScreenManager _screenManager;
        private void OnEnable()
        {
            if (!_button) _button = GetComponent<Button>();
            _button.onClick.AddListener(OverlayScreen);
        }

        public void SetupOverlayButton(GameObject overlayScreen, ScreenManager screenManager)
        {
            _overlayScreen = overlayScreen;
            _screenManager = screenManager;
        }
        private void OverlayScreen()
        {
            _screenManager.OpenOverlayScreen(_overlayScreen);
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OverlayScreen);
        }
    }
}
