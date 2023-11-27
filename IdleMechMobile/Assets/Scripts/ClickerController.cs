using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerController : MonoBehaviour
{
    [SerializeField]
    private Button moneyUpButton;
    [SerializeField]
    private TextMeshProUGUI moneyUpButtonText;
    private MoneyController _moneyController;

    private int _moneyIntIncrease = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!moneyUpButton)
        {
            Debug.Log("Missing money increase button");
        }

        if (!moneyUpButtonText)
        {
            Debug.Log("Missing money increase button text");
        }

        if (!_moneyController)
        {
            _moneyController = GetComponent<MoneyController>();
        }
    }

    public void CallIncreaseMoney(float amountToAdd)
    {
        if (amountToAdd > 0)
        {
            _moneyController.IncreaseMoney(amountToAdd);
        }
    }
    

    public void AddClickMoney()
    {
        _moneyController.IncreaseMoney(_moneyIntIncrease);
    }
    public void IncreaseClickValue()
    {
        _moneyIntIncrease++;
        moneyUpButtonText.text = "+" + _moneyIntIncrease + " Money";
    }
}
