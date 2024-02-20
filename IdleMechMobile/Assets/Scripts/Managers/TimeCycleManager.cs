using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Managers
{
    public class TimeCycleManager : Singleton<TimeCycleManager>
    {
        [SerializeField] float cycleDuration;
        [SerializeField] float cycleTimer;
        
        // an event for when the time cycle is over
        public UnityEvent OnTimeCycleOver;
     
        // Start is called before the first frame update
        void Start()
        {
            if(cycleDuration <= 0)
                cycleDuration = 6.0f;
            cycleTimer = cycleDuration;
        }

        // Update is called once per frame
        void Update()
        {
            cycleTimer -= Time.deltaTime;
            TextManager.Instance.UpdateCycleTimer(cycleTimer, cycleDuration);
            if (!(cycleTimer < 0.0f)) return;
            cycleTimer = cycleDuration;
            OnTimeCycleOver?.Invoke(); // ping all things that timer is over
            MonzManager.Instance.IncreaseMoney();
        }
    
        public void DecreaseCycleTimer(int multipler)
        {
            cycleDuration -= (0.1f * multipler);
        }
    }
}
