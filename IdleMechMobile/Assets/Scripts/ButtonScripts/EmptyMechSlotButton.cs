using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class EmptyMechSlotButton : ButtonParent
    {
        [SerializeField] private GameObject mechSelectionScreen;
        
        //What is needed:
            //The easiest way might just be having a second button in this process, doing the unlock code on it and keeping this button clean
        //Price for unlocked the button
        //Some way that allows the player to press the button to unlock without immediately opening the new mech screen
        //A way to check the player has the money required to unlock
        //A way to deduct the money from the player before the unlock happens
        //A way to scale the cost for the further down slots, may be able to use the GetSiblingIndex and multiply it against a value for cost
            //This could work, or we can do an array on the parent object to hold all the locked slots, keeps from issues happening because of a hierarchy move
        //Alright, new plan, new script written as the LockedMechSlotButton and replace this one with the default swapscreenbutton as that is all that would be left in this.
            
            
        //Future things:
        //A pre-built way of re-locking these slots for the future reset cycle
        //(DESIGN CHOICE)A way to decide how many buttons are locked, if I plan to add in a meta upgrade for more slots open at the start
        private void Start()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            
            
            //The code below will probably be dropped to just be handled with the ButtonUnlockManager
            //once testing is done
            if (transform.GetSiblingIndex() == 0)
            {
                return;
            }
            ButtonChild.interactable = false;
        }

        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();


            ButtonChild.onClick.AddListener(SwapToMechSelection);
            
        }

        private void SwapToMechSelection()
        {
            screenManagerChild.SwapScreenTo(mechSelectionScreen);
        }

        private void OnDisable()
        {
            ButtonChild.onClick.RemoveListener(SwapToMechSelection);
            
        }
    }
}
