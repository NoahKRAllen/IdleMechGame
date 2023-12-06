using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyCounterText;

    [SerializeField] private ClickerManager clickerManager;
    [SerializeField] private TextManager textManager;
    private float _moneyFloatHolder;

    private int _moneyPerTick;

    private void Start()
    {
        //This if check will be modified to respond when we load in the playerprefs
        //If the playerpref is empty, we set the value to default
        //if (PlayerPrefs.GetInt(UpgradeCost))
        //{
        //    UpdateMoneyUpgradeText();
        //    _currentUpgradeMoneyCost = PlayerPrefs.GetInt(UpgradeCost);
        //}
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

    public bool UpgradeClickValue(UpgradeSelectionInfo info)
    {
        if (info.upgradeCost > _moneyFloatHolder)
        {
            return false;
        }

        _moneyFloatHolder -= info.upgradeCost;
        info.upgradeCost += info.upgradeCost;
        UpdateMoneyText();
        textManager.UpdateUpgradeCostText(info.upgradeCost, info.upgradeTextConnection);
        clickerManager.IncreaseClickValue();
        return true;
    }
}
