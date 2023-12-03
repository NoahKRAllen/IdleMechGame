using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyCounterText;
    [SerializeField]
    private TextMeshProUGUI moneyUpgradeClickCostText;

    private int _currentUpgradeMoneyClickCost;
    
    private float _moneyFloatHolder;

    private int _moneyPerTick;

    private TextManager _textManager;

    private void Start()
    {
        //This if check will be modified to respond when we load in the playerprefs
        //If the playerpref is empty, we set the value to default
        //if (PlayerPrefs.GetInt(UpgradeCost))
        //{
        //    UpdateMoneyUpgradeText();
        //    _currentUpgradeMoneyCost = PlayerPrefs.GetInt(UpgradeCost);
        //}
        _currentUpgradeMoneyClickCost = 10;
        UpdateUpgradeCostText(_currentUpgradeMoneyClickCost, moneyUpgradeClickCostText);
    }

    public void IncreaseMoney(float amountToAdd)
    {
        _moneyFloatHolder += amountToAdd;
        UpdateMoneyText();
    }
    
    private void UpdateMoneyText()
    {
        moneyCounterText.text = "Money: $" + (int)_moneyFloatHolder;
    }
    public bool UpgradeClickValue()
    {
        if (_currentUpgradeMoneyClickCost > _moneyFloatHolder)
        {
            return false;
        }
        _moneyFloatHolder -= _currentUpgradeMoneyClickCost;
        _currentUpgradeMoneyClickCost += _currentUpgradeMoneyClickCost;
        UpdateMoneyText();
        UpdateUpgradeCostText(_currentUpgradeMoneyClickCost, moneyUpgradeClickCostText);
        //_clickerController.IncreaseClickValue(); //Swap this to TextManager instead of ClickerController
        return true;
    }

    private void UpdateUpgradeCostText(int upgradedCost, TMP_Text textToUpdate)
    {
        textToUpdate.text = "Spend $" + upgradedCost + " To Upgrade";
    }
}
