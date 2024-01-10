using BreakInfinity;
using TMPro;
using UnityEngine;

namespace Serialized
{
    [System.Serializable]
    public class PurchaseInfo : MonoBehaviour
    {
        [Header("Required Linked Objects")]
        public TextMeshProUGUI buttonTextConnection;
        public TextMeshProUGUI costTextConnection;

        //The upgradeCost will be the current amount that is required to pay for the upgrade, which is using a mathematical formula 
        //taking into account the totalAmount that the upgrade has been upgraded, as well as the initial cost. 
        //The only big issue I see with this is getting the multiple upgrade button working properly, as the math will have to get
        //the upgrade cost of each of the upcoming upgrades that fall within the upgrade group. 
        [Header("Mathematical Values")]
        //the way the BigDouble handles the mantissa & exponent is 10 = 1 mantissa 1 exponent  20 = 2 mantissa 1 exponent 25 = 2.5 mantissa 1 exponent  100 = 1 mantissa 2 exponent
        public BigDouble purchaseCost = new BigDouble(1, 1); 
        //Total upgrades that have been purchased of this type, used to calculate current price
        public BigDouble totalAmount = new BigDouble(1, 0);
        //Used as the basis to then be modified by total amount purchased for new cost NEED A BETTER WAY FOR MATHING THIS
        public BigDouble initialCost = new BigDouble(1, 1);
        public int multiplierAmount = 1;
    }
}
