using Managers;
using Serialized;
using UnityEngine;
using UnityEngine.UI;

namespace GameLoopScripts
{
    public class UpgradeMech : MonoBehaviour
    {
        private Button _button;
        private UpgradeInfo _upgradeInfo;
        [SerializeField] private UpgradeManager upgradeManager;
        private void OnEnable()
        {
            if (!_button) _button = GetComponent<Button>();
            if (!_upgradeInfo) _upgradeInfo = GetComponent<UpgradeInfo>();
            _button.onClick.AddListener(RequestMechUpgrade);
        }

        private void RequestMechUpgrade()
        {
            if (upgradeManager.CallUpgradeMech(_upgradeInfo))
            {
                //Do some fancy sound or visual here to show the player bought the mech
            }
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(RequestMechUpgrade);
        }
    }
}
