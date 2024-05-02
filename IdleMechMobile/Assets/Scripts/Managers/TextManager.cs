using BreakInfinity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class TextManager : Singleton<TextManager>
    {
        [SerializeField] private TextMeshProUGUI moneyCounterText;
        [SerializeField] private TextMeshProUGUI cycleValueText;
        [SerializeField] private TextMeshProUGUI cycleTimerText;
        [SerializeField] private GameObject cycleVisual;
        private Image _cycleFillIn;

        public void OnMonzChanged(GameObject monzManager)
        {
            var currentMonz = monzManager.GetComponent<MonzManager>().getCurrentMonz;
            UpdateMonzText(currentMonz);
        }

        public void OnTimeCycleDataChanged(GameObject timeCycleManager)
        {
            UpdateCycleTimer(
                timeCycleManager.GetComponent<TimeCycleManager>().getCycleTimer,
                timeCycleManager.GetComponent<TimeCycleManager>().getCycleDuration
            );
        }
        
        private void Start()
        {
            _cycleFillIn = cycleVisual.GetComponent<Image>();
        }

        public void UpdateUpgradeCostText(BigDouble upgradedCost, TMP_Text textToUpdate)
        {
            textToUpdate.text = $"Spend {upgradedCost.ToDouble()} Monz\nTo Upgrade";
        }
    
        public void UpdateMonzText(BigDouble value)
        {
            moneyCounterText.text = $"Monz: {value.ToDouble()}";
        }

        public void UpdateCycleValueText(BigDouble value)
        {
            cycleValueText.text = $"{value.ToDouble()} Monz Per Cycle";
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
