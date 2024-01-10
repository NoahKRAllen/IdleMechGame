using UnityEngine;

namespace Managers
{
    public class TimeCycleManager : MonoBehaviour
    {
        [SerializeField] private TextManager textManager;
        [SerializeField] private MoneyManager moneyManager;
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
            textManager.UpdateCycleTimer(cycleTimer, cycleDuration);
            if (!(cycleTimer < 0.0f)) return;
            cycleTimer = cycleDuration;
            moneyManager.IncreaseMoney();
        }
    
    
        public void DecreaseCycleTimer(int multipler)
        {
            cycleDuration -= (0.1f * multipler);
        }
    }
}
