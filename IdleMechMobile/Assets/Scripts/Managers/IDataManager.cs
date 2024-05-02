using UnityEngine.Events;

namespace Managers
{
    public interface IDataManager
    {
        void SubscribeToDataChanged(UnityAction listener);
        // void OnDataChanged();
    }
}