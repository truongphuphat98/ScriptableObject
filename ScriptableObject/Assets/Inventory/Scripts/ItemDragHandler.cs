using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField]
    private Transform ItemHolderParent;

    protected int slotIndex;
    protected ItemHolder.ItemSlot itemSlot;
    private Transform originalParent;
    private bool isDragging;

    public ItemHolder.ItemSlot GetItemSlot() { return itemSlot; }

    protected virtual void Start()
    {
        slotIndex = transform.parent.GetSiblingIndex();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        originalParent = transform.parent;
        transform.SetParent(ItemHolderParent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = false;
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    protected virtual void DropFromSlot()
    {
        //Find the Slot for this drag handler & drop the item
    }
}
