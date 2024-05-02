using UnityEngine;
using UnityEngine.Events;

namespace MVC.Controller
{
    public class FactorySlotController : MonoBehaviour
    {
        readonly FactorySlotView factorySlotview;
        readonly MothershipModel mothershipModel;
        readonly FactorySlotModel factorySlotModel;
        public UnityEvent FactorySlotsChanged; // an event to tell the view that slots have changed

        public FactorySlotController(FactorySlotView factorySlotview, MothershipModel mothershipModel, FactorySlotModel factorySlotModel)
        {
            this.factorySlotview = factorySlotview;
            this.mothershipModel = mothershipModel;
            this.factorySlotModel = factorySlotModel;
        }

        void OnEnable()
        {
            // subscribe to the events in the models and views that we care about
            // factorySlotModel.OnModelChanged += onFactorySlotModelChanged;
            // mothershipModel.OnModelChanged += onMothershipChanged;
            // factorySlotview.OnSlotClicked += onFactorySlotClicked;
            // this.factorySlotModel.OnTimeCycleOver.AddListener(AcceptTimerPing);
        }

        void OnDisable()
        {
            // factorySlotModel.OnModelChanged -= onFactorySlotModelChanged;
            // mothershipModel.OnModelChanged -= onMothershipChanged;
            // factorySlotview.OnSlotClicked -= onFactorySlotClicked;
        }
        

        private void onFactorySlotClicked()
        {
            Debug.Log($"Got a click from factory slot {factorySlotModel}");
            FactorySlotsChanged?.Invoke();
        }

        private void onMothershipChanged()
        {
            
        }
        private void onFactorySlotModelChanged()
        {
            Debug.Log($"Got a change from factory slot {factorySlotModel}");
            FactorySlotsChanged?.Invoke();
        }
        
        public void SubscribeToFactorySlotsChanged(UnityAction listener)
        {
            Debug.Log($"FSC: Subscribing to DataChanged on {gameObject.name} to {listener}", gameObject);
            FactorySlotsChanged.AddListener(listener);
        }
    }
}