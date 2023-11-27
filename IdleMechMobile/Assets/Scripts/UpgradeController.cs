using TMPro;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    private MoneyController _moneyController;

    private int _upgradeCost;
    private readonly int _initialUpgradeCost = 10;

    [SerializeField] private TextMeshProUGUI upgradeCost;
    
    private void Start()
    {
        if (!_moneyController)
        {
            _moneyController = GetComponent<MoneyController>();
        }

        if (_upgradeCost == 0)
        {
            _upgradeCost = _initialUpgradeCost;
        }
        upgradeCost.text = "Spend $" + _upgradeCost + " to upgrade";
    }

    public void UpgradeClickValue()
    {
        if (!_moneyController.UpgradeClickValue(_upgradeCost))
        {
            return;
        }
        //Using this to scale the cost in a linear way, will update this later to do proper
        //math for scaling
        _upgradeCost += _initialUpgradeCost;
        upgradeCost.text = "Spend $" + _upgradeCost + " to upgrade";
    }
}
