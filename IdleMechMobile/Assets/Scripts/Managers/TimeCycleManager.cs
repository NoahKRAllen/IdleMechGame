using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Managers
{
    public class TimeCycleManager : Singleton<TimeCycleManager>
    {
        [SerializeField] float cycleDuration;
        public float getCycleDuration => cycleDuration;
        [SerializeField] float cycleTimer;
        public float getCycleTimer => cycleTimer;

        public Event onTimeCycleOver;
        public Event onTimeCycleDataChanged;

        void Start()
        {
            if(cycleDuration <= 0)
                cycleDuration = 6.0f;
            cycleTimer = cycleDuration;
        }

        void Update()
        {
            cycleTimer -= Time.deltaTime;
            onTimeCycleDataChanged.Occurred(gameObject);
            // TextManager.Instance.UpdateCycleTimer(cycleTimer, cycleDuration);
            if (!(cycleTimer < 0.0f)) return;
            cycleTimer = cycleDuration;
            onTimeCycleOver.Occurred(this.gameObject);
        }
    
        public void DecreaseCycleTimer(int multipler)
        {
            cycleDuration -= (0.1f * multipler);
            onTimeCycleDataChanged.Occurred(gameObject);
        }
    }
}
