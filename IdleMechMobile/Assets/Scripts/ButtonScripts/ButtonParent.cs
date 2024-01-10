using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public abstract class ButtonParent : MonoBehaviour
    {
        protected Button ButtonChild;
        [SerializeField] protected ScreenManager screenManagerChild;

        //Only serializing this to allow changing on a few buttons that need to be locked
        [SerializeField] protected bool IsUnlocked;
        //Currently all buttons are unlocked, there needs to be a way to set 
        //the individual buttons to locked, based on the player's research
        //However the research system isn't in place yet, so I'm manually locking
        //down the buttons that need  to be locked.
        //IsUnlocked will not be saved with the PlayerPrefs, instead it will check
        //the saved research tree upon loading the game, and then unlocking each
        //button that is unlocked so far. The research tree's individual buttons will
        //be able to call the UnlockButton and LockButton for their required buttons
        //since the commands are held in the ButtonUnlockManager as static calls
        
        
        
        
        //Calls used only within the ButtonUnlockManager, storied here to allow
        //ButtonUnlockManager to be completely static for ease of access across
        //multiple classes
        public virtual void UnlockButton()
        {
            IsUnlocked = true;
            ButtonChild.interactable = true;
        }

        public void LockButton()
        {
            IsUnlocked = false;
            ButtonChild.interactable = false;
        }
    }
}
