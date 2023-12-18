using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void UpdateUpgradeCostText(int upgradedCost, TMP_Text textToUpdate)
    {
        textToUpdate.text = "Spend " + upgradedCost + " Matter To Upgrade";
    }
    
    public void UpdateMoneyText(int value)
    {
        moneyCounterText.text = "Matter: " + value;
    }

    public void UpdateCycleValueText(int value)
    {
        cycleValueText.text = value + " Per Cycle";
    }

    public void UpdateCycleTimer(float value, float maxValue)
    {
        _cycleFillIn.fillAmount = (value / maxValue);
        cycleTimerText.text = value.ToString("F2");
    }
}
