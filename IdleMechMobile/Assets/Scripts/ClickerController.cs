using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerController : MonoBehaviour
{
    private Button _selfButton;

    private TextMeshProUGUI _selfButtonText;
    [SerializeField]
    private TextMeshProUGUI moneyCounter;

    private int _moneyIntHolder = 0;
    private int _moneyIntIncrease = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!_selfButton)
        {
            _selfButton = GetComponent<Button>();
        }

        if (!_selfButtonText)
        {
            _selfButtonText = GetComponentInChildren<TextMeshProUGUI>();
        }

        if (!moneyCounter)
        {
            gameObject.SetActive(false);
        }

        moneyCounter.text = "Money: " + _moneyIntHolder;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncreaseMoney()
    {
        _moneyIntHolder += _moneyIntIncrease;
        moneyCounter.text = "Money " + _moneyIntHolder;
    }

    public void IncreaseClickValue()
    {
        _moneyIntIncrease++;
        _selfButtonText.text = "+" + _moneyIntIncrease + " Money";
    }
}
