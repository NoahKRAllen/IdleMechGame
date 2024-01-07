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
            textToUpdate.text = "Spend " + upgradedCost + " Monz To Upgrade";
        }
    
        public void UpdateMoneyText(BigDouble value)
        {
            moneyCounterText.text = "Monz: " + value;
        }

        public void UpdateCycleValueText(BigDouble value)
        {
            cycleValueText.text = value + " Per Cycle";
        }

        public void UpdateCycleTimer(float value, float maxValue)
        {
            _cycleFillIn.fillAmount = (value / maxValue);
            cycleTimerText.text = value.ToString("F2");
        }
    }
}
