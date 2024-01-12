using UnityEngine;

namespace Serialized
{
    public class MultiplierButton : MonoBehaviour
    {
        [SerializeField] private PurchaseInfo[] upgradeButtons;
        
        
        //TODO: OnEnable onClick setup
        //      OnDisable onClick cleanuo
        //      Function to request an increase of the price of the buttons, while also changing the text to show new price
        //      Function to handle the increased upgrade total that will be bought
        //      Testing done to ensure that the multiplied amount actually gets added in once clicked
    }
}
