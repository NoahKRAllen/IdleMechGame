using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class SwapScreenButton : ButtonParent
    {
        [SerializeField] private GameObject swapScreen;
        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            ButtonChild.onClick.AddListener(SwapScreen);
        }
    
        private void SwapScreen()
        {
            screenManagerChild.SwapScreenTo(swapScreen);
        }

        private void OnDisable()
        {
            ButtonChild.onClick.RemoveListener(SwapScreen);
        }

        public void ChangeTargetScreen(GameObject newScreen)
        {
            swapScreen = newScreen;
        }
    }
}
