using ButtonScripts;
using UnityEngine;

namespace Managers
{
    public class ButtonUnlockManager : MonoBehaviour
    {
        public static void UnlockButton(ButtonParent buttonToUnlock)
        {
            buttonToUnlock.UnlockButton();
        }

        public static void LockButton(ButtonParent buttonToLock)
        {
            buttonToLock.LockButton();
        }
    }
}
