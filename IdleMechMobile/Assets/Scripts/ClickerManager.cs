using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    [SerializeField]
    private Button moneyUpButton;
    [SerializeField]
    private TextMeshProUGUI moneyUpButtonText;
    private MoneyManager _moneyManager;

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

        if (!_moneyManager)
        {
            _moneyManager = GetComponent<MoneyManager>();
        }
    }
    public void AddClickMoney()
    {
        _moneyManager.IncreaseMoney(_moneyIntIncrease);
    }
    public void IncreaseClickValue()
    {
        _moneyIntIncrease++;
        //Leaving this text swap here as I shouldn't be modifying it from anywhere else currently, so no need to put
        //it within the TextManager
        moneyUpButtonText.text = "+" + _moneyIntIncrease + " Money";
    }
}
