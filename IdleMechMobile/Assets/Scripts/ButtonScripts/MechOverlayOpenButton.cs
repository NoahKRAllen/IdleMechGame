using DataPersistence;
using MechMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class MechOverlayOpenButton : ButtonParent
    {
        private MechSlot _mechSlot;
        private GameObject _overlayScreen;

        private bool _mechSelected;
        //private IndividualMechScreen _mechScreen; ignoring this for now
        [SerializeField] private GameObject swapScreen;

        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            if (!_mechSlot) _mechSlot = GetComponent<MechSlot>();
            
            if (!_mechSlot.CheckMechSelected())
            {
                ButtonChild.onClick.AddListener(MechOverlaySwapScreen);
                _mechSelected = false;
            }

            if (_mechSlot.CheckMechSelected() && _mechSlot == _mechSlot.RequestActiveMechSlot())
            {
                _mechSlot.SetupOverlayButton();
                _mechSelected = true;
            }
        }
        
        private void MechOverlaySwapScreen()
        {
            _mechSlot.PassActiveSlotUp();
            screenManagerChild.SwapScreenTo(swapScreen);
        }
        
        
        public void SetupListeningOverlayButton(GameObject overlayScreen)
        {
            _overlayScreen = overlayScreen;
            ButtonChild.onClick.AddListener(OverlayScreen);

            //_mechScreen = _overlayScreen.GetComponent<IndividualMechScreen>();
        }
        private void OverlayScreen()
        {
            screenManagerChild.OpenOverlayScreen(_overlayScreen);
        }
        
        
        private void OnDisable()
        {
            if (!_mechSlot.CheckMechSelected())
            {
                ButtonChild.onClick.RemoveListener(MechOverlaySwapScreen);
            }
            else
            {
                ButtonChild.onClick.RemoveListener(OverlayScreen);
            }

        }

        public GameObject GetOverlayScreen()
        {
            return _overlayScreen;
        }

        public bool IsMechSelected()
        {
            return _mechSelected;
        }
    }
}
