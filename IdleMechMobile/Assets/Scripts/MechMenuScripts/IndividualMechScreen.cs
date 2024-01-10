using UnityEngine;

namespace MechMenuScripts
{
    public class IndividualMechScreen : MonoBehaviour
    {
        //This value is dependent on how many mechs have been selected to be deployed before this mech,
        //causing this mech's costs to increase because of the supply cost
        private int _costMultiplier = 1;

        public void SetCostMultiplier(int newMultiplier)
        {
            _costMultiplier = newMultiplier;
        }
    }
}
