using MechMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class MechSelectionScreenManager : MonoBehaviour
    {
        [SerializeField] private MechMenuScripts.MothershipManager mechSlotParent;

        public void AffectMechSlot(string mechName, GameObject overlayScreen)
        {
            mechSlotParent.AffectMechSlot(mechName, overlayScreen);
        }
    }
}
