using Managers;
using MechMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class SelectMechTypeButton : ButtonParent
    {
        //Now we must make logic in here to lock down the extra mech types unless they have been
        //researched through the upgrade tree
        private MechSlot _mechSlot;
        [SerializeField] private MechSelectionScreenManager mechSelectionScreenManager;
        [SerializeField] private string mechName;
        [SerializeField] private GameObject overlayScreen;
        [SerializeField] private GameObject mechPurchaseScreen;
        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            

            ButtonChild.onClick.AddListener(CallSelectMech);
        }

        private void CallSelectMech()
        {
            //mechSelectionScreenManager.MechSelected(ButtonChild);
            ButtonChild.interactable = false;
            mechSelectionScreenManager.AffectMechSlot(mechName, overlayScreen);
            screenManagerChild.SwapScreenTo(mechPurchaseScreen);
        }

        private void OnDisable()
        {
            ButtonChild.onClick.RemoveListener(CallSelectMech);
            
        }
    }
}
