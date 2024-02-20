using Managers;
using MechMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    [RequireComponent(typeof(Button))]
    public class SelectMechTypeButton : ButtonParent
    {
        //Now we must make logic in here to lock down the extra mech types unless they have been
        //researched through the upgrade tree
        private MechSlot _mechSlot;
        [SerializeField] private MechSelectionScreenManager mechSelectionScreenManager;
        
        // public get private set private string mechName
        [SerializeField] private string mechName;
        public string MechName
        {
            get => mechName;
            private set => mechName = value;
        }
        
        [SerializeField] private GameObject overlayScreen;
        [SerializeField] private GameObject mechPurchaseScreen;
        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            ButtonChild.onClick.AddListener(CallSelectMech);
        }

        public void CallSelectMech()
        {
            if (! MonzManager.Instance.IsLoading )
            {
                ButtonChild.interactable = false;
            }
            mechSelectionScreenManager.AffectMechSlot(mechName, overlayScreen);
            screenManagerChild.SwapScreenTo(mechPurchaseScreen);
        }

        private void OnDisable()
        {
            ButtonChild.onClick.RemoveListener(CallSelectMech);
            
        }
    }
}
