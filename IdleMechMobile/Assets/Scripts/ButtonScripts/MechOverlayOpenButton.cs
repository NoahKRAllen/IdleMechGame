using Managers;
using MechMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class MechOverlayOpenButton : ButtonParent
    {
        private GameObject _overlayScreen;
        private IndividualMechScreen _mechScreen;

        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            
            if(IsUnlocked) ButtonUnlockManager.UnlockButton(this);

            ButtonChild.onClick.AddListener(OverlayScreen);
        }

        public void SetupOverlayButton(GameObject overlayScreen, ScreenManager screenManager, int totalDifferentMechs)
        {
            _overlayScreen = overlayScreen;
            _mechScreen = _overlayScreen.GetComponent<IndividualMechScreen>();
            _mechScreen.SetCostMultiplier(totalDifferentMechs);
            screenManagerChild = screenManager;
        }
        private void OverlayScreen()
        {
            screenManagerChild.OpenOverlayScreen(_overlayScreen);
        }
        
        private void OnDisable()
        {
            ButtonChild.onClick.RemoveListener(OverlayScreen);
            
            if(IsUnlocked) ButtonUnlockManager.UnlockButton(this);

        }
    }
}
