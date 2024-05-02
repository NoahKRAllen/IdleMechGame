using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MothershipController : MonoBehaviour
{
    readonly MothershipView view;
    readonly MothershipModel model;
    readonly int mechFactorySlots;
    readonly string mothershipName;
    
    public MothershipController(MothershipView view, MothershipModel model, int mechFactorySlots, string mothershipName)
    {
        // setup the controller's access to everything when it is first created from the manager
        this.view = view;
        this.model = model;
        this.mechFactorySlots = mechFactorySlots;
        this.mothershipName = mothershipName;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        view.InitializeView(new ViewModel(model, mechFactorySlots, mothershipName));
        
        view.OnClick += HandleOnClick;
        // model.OnModelChanged += HandleModelChanged;
        RefreshView();
    }

    void HandleOnClick(MothershipController mothershipController)
    {
        Debug.Log($"got click on {mothershipController.mothershipName}");
    }
    
    void HandleModelChanged()
    {
        RefreshView();
    }
    
    void RefreshView()
    {
        for (int i = 0; i < mechFactorySlots; i++)
        {
            // do some business logic here
            // view.FactorySlot[i].Set(slot);
        }
        view.RefreshView();
    }
    
}

public class ViewModel
{
    public readonly int MechFactorySlots;
    public readonly string MothershipName;

    public ViewModel(MothershipModel model, int mechFactorySlots, string mothershipName)
    {
        MechFactorySlots = mechFactorySlots;
        MothershipName = mothershipName;
    }
}