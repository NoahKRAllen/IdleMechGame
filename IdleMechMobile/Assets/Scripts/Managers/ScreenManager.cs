using MechMenuScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        [SerializeField] private ScreenView currentlyActiveScreen;
        private GameObject _activeOverlayScreen;
        [FormerlySerializedAs("MechSlotsParent")] [SerializeField] private MechMenuScripts.MothershipManager mothershipManager;
        

        // TODO:  initialize a state machine with conditions on what screens can swap to each other


        private void Start()
        {
            
            //Need a better way to default to a specific GameObject, but without linking it to the script
            //Could do a GetComponent if I have a component on the default screen that I can go searching for
            if (!currentlyActiveScreen)
            {
                Debug.LogError($"No default current screen set in {gameObject.name}", gameObject);
                // currentlyActiveScreen = GameObject.Find("MainGameScreen");
            }

            SwapScreenTo(currentlyActiveScreen);
            
        }

        public void SwapScreenTo(ScreenView screenToSwapTo)
        {
            if (screenToSwapTo == null)
            {
                Debug.LogWarning("ScreenManager: Attempted to swap to a null screen", gameObject);
                return;
            }
            Debug.Log($"SM: swapping from {currentlyActiveScreen.gameObject.name} to {screenToSwapTo.gameObject.name}");
            // TODO: Move currently active screen back to its initial position in the scene
            currentlyActiveScreen.ResetToOriginalPosition();

            // Set the currently active screen to the new screen
            currentlyActiveScreen = screenToSwapTo;
            currentlyActiveScreen.GetComponent<RectTransform>().anchoredPosition  = new Vector3(0, -480, 0);
        }

        public void OpenOverlayScreen(GameObject overlayScreen)
        {
            Debug.Log($"SM: Opening overlay screen: {overlayScreen.name}", gameObject);
            // TODO: move the current overlay screen back to where it was before
            
            _activeOverlayScreen = overlayScreen;
            _activeOverlayScreen.GetComponent<RectTransform>().anchoredPosition  = new Vector3(0, -480, 0);
            // _activeOverlayScreen.SetActive(true);
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
            mothershipManager.ClearSelectedMechSlot();
        }
    }
}
