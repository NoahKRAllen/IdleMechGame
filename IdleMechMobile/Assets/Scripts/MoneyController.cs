using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class MoneyController : MonoBehaviour
{
    [FormerlySerializedAs("moneyCounter")] [SerializeField]
    private TextMeshProUGUI moneyCounterText;
    
    private float _moneyFloatHolder;

    private ClickerController _clickerController;

    private void Start()
    {
        if (!_clickerController)
        {
            _clickerController = GetComponent<ClickerController>();
        }
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
    public bool UpgradeClickValue(int upgradeCost)
    {
        if (upgradeCost > _moneyFloatHolder)
        {
            return false;
        }
        _moneyFloatHolder -= upgradeCost;

        UpdateMoneyText();
        
        _clickerController.IncreaseClickValue();
        return true;
    }
}
