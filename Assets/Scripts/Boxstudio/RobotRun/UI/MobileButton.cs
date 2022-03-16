using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.Events;

namespace Boxstudio.RobotRun.UI {
    public class MobileButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] UnityEvent _onClick = new UnityEvent();
        public UnityEvent onClick { get { return _onClick; } set {_onClick = value; } }

        public void OnPointerDown(PointerEventData eventData)
        {
            onClick.Invoke();
        }
    }
}
