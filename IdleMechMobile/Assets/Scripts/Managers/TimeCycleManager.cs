using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class TimeCycleManager : Singleton<TimeCycleManager>
    {
        [SerializeField] float cycleDuration;
        [SerializeField] float cycleTimer;
     
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
            MonzManager.Instance.IncreaseMoney();
        }
    
    
        public void DecreaseCycleTimer(int multipler)
        {
            cycleDuration -= (0.1f * multipler);
        }
    }
}
