using UnityEngine;

namespace Managers
{
    public class TimeCycleManager : MonoBehaviour
    {
        [SerializeField] private TextManager textManager;
        [SerializeField] private MoneyManager moneyManager;
        private float _cycleDuration;
        private float _cycleTimer;
        // Start is called before the first frame update
        void Start()
        {
            _cycleDuration = 6.0f;
            _cycleTimer = _cycleDuration;
        }

        // Update is called once per frame
        void Update()
        {
            _cycleTimer -= Time.deltaTime;
            textManager.UpdateCycleTimer(_cycleTimer, _cycleDuration);
            if (!(_cycleTimer < 0.0f)) return;
            _cycleTimer = _cycleDuration;
            moneyManager.IncreaseMoney();
        }
    
    
        public void DecreaseCycleTimer(int multipler)
        {
            _cycleDuration -= (0.1f * multipler);
        }
    }
}
