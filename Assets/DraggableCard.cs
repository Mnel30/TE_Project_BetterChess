using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;
    public bool isBeingDragged = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);  // Detach from the hand panel (or original parent)
        isBeingDragged = true;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;  // Follow the cursor
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isBeingDragged) return;
        transform.SetParent(originalParent);  // Return to the original parent if not dropped in a valid zone
        transform.localPosition = Vector3.zero;  // Reset position
        isBeingDragged = false;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
