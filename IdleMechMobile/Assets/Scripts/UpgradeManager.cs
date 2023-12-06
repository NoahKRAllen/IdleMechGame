using TMPro;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    private MoneyManager _moneyManager;
    private void Start()
    {
        if (!_moneyManager)
        {
            _moneyManager = GetComponent<MoneyManager>();
        }
    }

    public void CallUpgradeClickValue(UpgradeSelectionInfo info)
    {
        _moneyManager.UpgradeClickValue(info);
    }
}
