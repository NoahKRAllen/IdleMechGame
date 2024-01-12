using BreakInfinity;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Serialized
{
    [System.Serializable]
    public class UpgradeInfo : MonoBehaviour
    {
        [Header("Required Linked Objects")]
        //ButtonTextConnection will be used for changing the button text when the multiplier button is pressed so it shows how many of the upgrade the user is trying to buy
        public TextMeshProUGUI buttonTextConnection;
        public TextMeshProUGUI costTextConnection;
        public string mechName;
        
        [Header("Mathematical Values")]
        //the way the BigDouble handles the mantissa & exponent is 10 = 1 mantissa 1 exponent  20 = 2 mantissa 1 exponent 25 = 2.5 mantissa 1 exponent  100 = 1 mantissa 2 exponent
        public BigDouble upgradeCost = new BigDouble(1, 1); 
        //Total upgrades that have been purchased of this type, used to calculate current price
        public BigDouble totalAmount = new BigDouble(1, 0);
        //Used as the basis to then be modified by total amount purchased for new cost NEED A BETTER WAY FOR MATHING THIS
        public BigDouble initialCost = new BigDouble(1, 1);
        public int multiplierAmount = 1;
    }
}
