using MechMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class MechSelectionScreenManager : MonoBehaviour
    {
        private MechSlot _currentMechSlot;

        [SerializeField] private MechSlotsParent mechSlotParent;
        //This is going to be heavily modified once I do a UI visual pass
        //Currently its just going to be turning the button for the mech panel to un-interactable, to stop the user from selecting
        //the same mech repeatedly. This will be changed to modifying the panel itself in some beautiful effects like chains, while
        //also turning the button to un-interactable.
        //Technically the way it is being handled currently it makes more sense to do a listener on the button,
        //but since I plan to expand what happens in this function, I'm leaving it separate for now.
        public void MechSelected(/*GameObject mechSelectionPanel*/ Button mechSelectionButton)
        {
            mechSelectionButton.interactable = false;
        }

        public void AffectMechSlot(string mechName, GameObject overlayScreen)
        {
            mechSlotParent.AffectMechSlot(mechName, overlayScreen);
        }
        public void SetCurrentMechSlot(MechSlot incomingMechSlot)
        {
            _currentMechSlot = incomingMechSlot;
        }
    }
}
