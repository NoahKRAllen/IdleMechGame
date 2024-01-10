using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class SelectMechTypeButton : ButtonParent
    {
        //Now we must make logic in here to lock down the extra mech types unless they have been
        //researched through the upgrade tree
        //Actually might just make a secondary script for them that sets them non-interactable
        //and then is what is called when the upgrade is done
        [SerializeField] private MechSelectionScreenManager mechSelectionScreenManager;
        [SerializeField] private PurchaseScreenManager purchaseScreenManager;
        [SerializeField] private string mechName;
        [SerializeField] private GameObject overlayScreen;
        [SerializeField] private GameObject mechPurchaseScreen;
        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            
            if(IsUnlocked) ButtonUnlockManager.UnlockButton(this);
            
            ButtonChild.onClick.AddListener(CallSelectMech);
        }

        private void CallSelectMech()
        {
            purchaseScreenManager.SetButtonText(mechName);
            purchaseScreenManager.SetOverlayScreen(overlayScreen);
            mechSelectionScreenManager.MechSelected(ButtonChild);
            screenManagerChild.SwapScreenTo(mechPurchaseScreen);
        }

        private void OnDisable()
        {
            ButtonChild.onClick.RemoveListener(CallSelectMech);
            
            if(IsUnlocked) ButtonUnlockManager.UnlockButton(this);

        }
    }
}
