using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InteractableElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public UnityEvent pointerClick = new UnityEvent();
    public UnityEvent pointerDown = new UnityEvent();
    public UnityEvent pointerUp = new UnityEvent();

    public virtual void OnPointerClick(PointerEventData eventData) => pointerClick?.Invoke();
    public virtual void OnPointerDown(PointerEventData eventData) => pointerDown?.Invoke();
    public virtual void OnPointerUp(PointerEventData eventData) => pointerUp?.Invoke();
}
