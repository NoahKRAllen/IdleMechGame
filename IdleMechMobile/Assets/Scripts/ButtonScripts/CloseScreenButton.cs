using UnityEngine.UI;

namespace ButtonScripts
{
    public class CloseScreenButton : ButtonParent
    {
        
        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();

            IsUnlocked = true;

            if(IsUnlocked) Managers.ButtonUnlockManager.UnlockButton(this);
            ButtonChild.onClick.AddListener(CloseOverlay); 
        }

        private void CloseOverlay()
        {
            screenManagerChild.CloseOverlayScreen();
        }
        
        private void OnDisable()
        {
            ButtonChild.onClick.RemoveListener(CloseOverlay);
            
            Managers.ButtonUnlockManager.LockButton(this);
        }
    }
}
