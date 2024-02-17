using System;
using Serialized;
using UnityEngine;
using UnityEngine.UI;
using Managers;

namespace GameLoopScripts
{
    //Not making ButtonParent the parent of these scripts as we need nothing in that script for what happens here
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(PurchaseInfo))]
    public class PurchaseMech : MonoBehaviour
    {
        private Button _button;
        private PurchaseInfo _purchaseInfo;
        // [SerializeField] private UpgradeManager upgradeManager;
        private void OnEnable()
        {
            if (!_button) _button = GetComponent<Button>();
            if (!_purchaseInfo) _purchaseInfo = GetComponent<PurchaseInfo>();
            _button.onClick.AddListener(RequestMechPurchase);
        }

        private void RequestMechPurchase()
        {
            if (UpgradeManager.Instance.CallPurchaseMech(_purchaseInfo))
            {
                //Do some fancy sound or visual here to show the player bought the mech
            }
            else
            {
                Debug.Log($"Didn't have enough monz according to {_purchaseInfo.purchaseCost}");
            }
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(RequestMechPurchase);
        }
    }
}
