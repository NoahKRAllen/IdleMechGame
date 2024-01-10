using UnityEngine.UI;

namespace ButtonScripts
{
    public class CloseScreenButton : ButtonParent
    {
        
        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            ButtonChild.onClick.AddListener(CloseOverlay); 
        }

        private void CloseOverlay()
        {
            screenManagerChild.CloseOverlayScreen();
        }
        
        private void OnDisable()
        {
            ButtonChild.onClick.RemoveListener(CloseOverlay);
        }
    }
}
