using TMPro;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    private MoneyController _moneyController;
    private void Start()
    {
        if (!_moneyController)
        {
            _moneyController = GetComponent<MoneyController>();
        }
    }

    public void CallUpgradeClickValue()
    {
        _moneyController.UpgradeClickValue();
    }
}
