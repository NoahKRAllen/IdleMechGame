using BreakInfinity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class TextManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyCounterText;

        [SerializeField] private TextMeshProUGUI cycleValueText;
        [SerializeField] private TextMeshProUGUI cycleTimerText;
        [SerializeField] private GameObject cycleVisual;
        private Image _cycleFillIn;

        private void Start()
        {
            _cycleFillIn = cycleVisual.GetComponent<Image>();
        }

        public void UpdateUpgradeCostText(BigDouble upgradedCost, TMP_Text textToUpdate)
        {
            textToUpdate.text = "Spend " + upgradedCost.ToString("G6") + " Monz To Upgrade";
        }
    
        public void UpdateMonzText(BigDouble value)
        {
            moneyCounterText.text = "Monz: " + value.ToString("G6");
        }

        public void UpdateCycleValueText(BigDouble value)
        {
            cycleValueText.text = value.ToString("G6") + " Monz Per Cycle";
        }

        public void UpdateCycleTimer(float value, float maxValue)
        {
            _cycleFillIn.fillAmount = (value / maxValue);
            cycleTimerText.text = value.ToString("F2");
        }

        public static void UpdateAnyBasicText(TextMeshProUGUI text, string newText)
        {
            text.text = newText;
        }
    }
}
