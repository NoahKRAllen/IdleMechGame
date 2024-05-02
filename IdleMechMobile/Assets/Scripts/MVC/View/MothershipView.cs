using System;
using UnityEngine;

public class MothershipView : MonoBehaviour
{
    public MothershipController mothershipController;

    public void InitializeView(ViewModel viewModel)
    {
        // throw new System.NotImplementedException();
    }

    public event Action<MothershipController> OnClick;

    private void Awake()
    {
        mothershipController = GetComponent<MothershipController>();
        
    }

    public void RefreshView()
    {
        // throw new NotImplementedException();
    }
}