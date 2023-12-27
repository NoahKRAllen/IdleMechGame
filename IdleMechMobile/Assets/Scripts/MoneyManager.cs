using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextManager textManager;
    private int _moneyIntHolder;

    private int _moneyPerTick;

    private float _cycleDuration;
    private float _cycleTimer;

    private void Start()
    {
        //This if check will be modified to respond when we load in the playerprefs
        //If the playerpref is empty, we set the value to default
        //if (PlayerPrefs.GetInt(UpgradeCost))
        //{
        //    UpdateMoneyUpgradeText();
        //    _currentUpgradeMoneyCost = PlayerPrefs.GetInt(UpgradeCost);
        //}
        //Default duration will be one second for each tick
        _cycleDuration = 6.0f;
        _cycleTimer = _cycleDuration;
    }

    private void Update()
    {
        _cycleTimer -= Time.deltaTime;
        textManager.UpdateCycleTimer(_cycleTimer, _cycleDuration);
        if (!(_cycleTimer < 0.0f)) return;
        _cycleTimer = _cycleDuration;
        IncreaseMoney(_moneyPerTick);
    }

    public void IncreaseMoney(int amountToAdd)
    {
        _moneyIntHolder += amountToAdd;
        textManager.UpdateMoneyText(_moneyIntHolder);
    }

    public void IncreaseTickValue()
    {
        _moneyPerTick++;
        textManager.UpdateCycleValueText(_moneyPerTick);
    }

    public bool UpgradeValue(UpgradeSelectionInfo info)
    {
        if (info.upgradeCost > _moneyIntHolder)
        {
            return false;
        }

        _moneyIntHolder -= info.upgradeCost;
        //This is the current way we calculate the cost of each upgrade, based off its initial cost times the total
        //amount of times its been upgraded
        info.totalAmount++;
        info.upgradeCost = info.initialCost * info.totalAmount;
        textManager.UpdateMoneyText(_moneyIntHolder);
        textManager.UpdateUpgradeCostText(info.upgradeCost, info.upgradeTextConnection);
        return true;
    }

    public void DecreaseCycleTimer()
    {
        _cycleDuration -= 0.1f;
    }
}
