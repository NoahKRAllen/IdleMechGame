using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using MechMenuScripts;
using MVC.Controller;
using UnityEngine;
using UnityEngine.Events;

// FactorySlotView is a child of ScreenView.  This particular view subscribes to data from the Factory
public class FactorySlotView : ScreenView
{
    [SerializeField] private GameObject[] mechFactorySlots;
    public GameObject FactorySlotUIParent;
    // public UnityEvent OnSlotClicked;
    // public UnityEvent OnSlotHovered;
    public Event OnFactorySlotClicked;
    public GameObject PurchaseFactoryPrefab;
    public GameObject PurchaseMechPrefab;

    private void OnMouseDown()
    {
        // OnSlotClicked?.Invoke();
        Debug.Log($"button was clicked");
        OnFactorySlotClicked.Occurred(this.gameObject); // TODO: how to I tell it which button was clicked?
    }

    protected override void Start()
    {
        base.Start();
        Debug.Log($"FSV: started in FactorySlotView on object {gameObject.name}", gameObject);
        // TODO: create X factory slots under FactorySlotUIParent
    }
    
    private void FactorySlotChanged()
    {
        // TODO: do something when a factory slot changes
        Debug.Log("FSV: TODO:  Mothership's factory slot view changed.  Need to rebuild UI.", gameObject);
        
    }



}
