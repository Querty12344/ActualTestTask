using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.GamePlay
{
    public class ButtonPressedInfo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool Pressed { get; private set; }
        public void OnPointerDown(PointerEventData eventData) => Pressed = true;
        public void OnPointerUp(PointerEventData eventData) => Pressed = false;
    }
}