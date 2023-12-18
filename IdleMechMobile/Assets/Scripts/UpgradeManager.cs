using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private MoneyManager _moneyManager;
    private ClickerManager _clickerManager;
    private void Start()
    {
        if (!_moneyManager)
        {
            _moneyManager = GetComponent<MoneyManager>();
        }

        if (!_clickerManager)
        {
            _clickerManager = GetComponent<ClickerManager>();
        }
    }

    #region MaterialCollectionUpgrades
    public void CallUpgradeClickValue(UpgradeSelectionInfo info)
    {
        if (_moneyManager.UpgradeValue(info))
        {
            _clickerManager.IncreaseClickValue();
        }
    }

    public void CallUpgradeCycleValue(UpgradeSelectionInfo info)
    {
        if (_moneyManager.UpgradeValue(info))
        {
            _moneyManager.IncreaseTickValue();
        }
    }

    public void CallUpgradeCycleTimer(UpgradeSelectionInfo info)
    {
        if (_moneyManager.UpgradeValue(info))
        {
            _moneyManager.DecreaseCycleTimer();
        }
    }
    #endregion
}
