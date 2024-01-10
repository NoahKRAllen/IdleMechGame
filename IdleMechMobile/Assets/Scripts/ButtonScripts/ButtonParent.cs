using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class ButtonParent : MonoBehaviour
    {
        protected Button ButtonChild;
        [SerializeField] protected ScreenManager screenManagerChild;
    }
}
