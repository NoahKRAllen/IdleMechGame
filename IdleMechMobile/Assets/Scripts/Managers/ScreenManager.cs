using MechMenuScripts;
using UnityEngine;

namespace Managers
{
    public class ScreenManager : MonoBehaviour
    {
        [SerializeField] private GameObject currentlyActiveScreen;
        private GameObject _activeOverlayScreen;
        [SerializeField] private MechSlotsParent MechSlotsParent;
        private void Start()
        {
            if (currentlyActiveScreen) return;
            //Need a better way to default to a specific GameObject, but without linking it to the script
            //Could do a GetComponent if I have a component on the default screen that I can go searching for
            currentlyActiveScreen = GameObject.Find("MainGameScreen");
            SwapScreenTo(currentlyActiveScreen);
        }

        public void SwapScreenTo(GameObject screenToSwapTo)
        {
            currentlyActiveScreen.SetActive(false);
            currentlyActiveScreen = screenToSwapTo;
            currentlyActiveScreen.SetActive(true);
        }

        public void OpenOverlayScreen(GameObject overlayScreen)
        {
            Debug.Log($"SM: Opening overlay screen: {overlayScreen.name}", gameObject);
            _activeOverlayScreen = overlayScreen;
            _activeOverlayScreen.SetActive(true);
        }

        public void OpenOverlayScreen(GameObject overlayScreen, int differentMechs)
        {
            OpenOverlayScreen(overlayScreen);
            
        }
        
        public void CloseOverlayScreen()
        {
            Debug.Log($"SM: Closing all overlay screens", gameObject);
            _activeOverlayScreen.SetActive(false);
            _activeOverlayScreen = null;
            
            // todo: tell MechSlotsParent to clear his state tracking as well
            MechSlotsParent.ClearSelectedMechSlot();
        }
    }
}
