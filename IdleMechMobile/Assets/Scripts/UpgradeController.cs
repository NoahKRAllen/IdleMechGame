using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    private Button _selfButton;
    [SerializeField]
    private TextMeshProUGUI moneyIncreaseCounter;

    [SerializeField] 
    private ClickerController moneyIncreaseButtonController;

    
    // Start is called before the first frame update
    void Start()
    {
        if (!_selfButton)
        {
            _selfButton = GetComponent<Button>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeClickValue()
    {
        moneyIncreaseButtonController.IncreaseClickValue();
    }
}
