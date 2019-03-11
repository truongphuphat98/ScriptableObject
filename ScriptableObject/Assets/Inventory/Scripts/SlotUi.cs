using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class SlotUi : MonoBehaviour
{
    protected GameObject icon;
    protected int slotIndex;
    private Text stack;

    protected ItemHolder.ItemSlot thisItemSlot;
    protected ItemHolder.ItemSlot droppedItemSlot;

    protected virtual void Start()
    {
        slotIndex = transform.GetSiblingIndex();
        icon = transform.GetChild(0).gameObject;
        stack = icon.transform.GetChild(0).GetComponent<Text>();
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        droppedItemSlot = eventData.pointerDrag.GetComponent<ItemDragHandler>().GetItemSlot();
    }

    protected void HandleItemDrop(PointerEventData eventData)
    {
        if (thisItemSlot.item != null)
        {
            if (thisItemSlot.item == droppedItemSlot.item)
            {
                if (thisItemSlot.currentStack < thisItemSlot.item.maxStack)
                {
                    if (droppedItemSlot.currentStack <= thisItemSlot.item.maxStack - thisItemSlot.currentStack)
                    {
                        thisItemSlot.currentStack += droppedItemSlot.currentStack;

                        droppedItemSlot.Clear();
                    }
                    else
                    {
                        int stackDifference = thisItemSlot.item.maxStack - thisItemSlot.currentStack;

                        thisItemSlot.currentStack += stackDifference;

                        droppedItemSlot.currentStack -= stackDifference;
                    }
                }
            }
            else
            {
                SwapItems(eventData);
            }
        }
        else
        {
            DroppedOnToEmptySlot();
        }
        //Update UI
    }

    private void DroppedOnToEmptySlot()
    {
        thisItemSlot.item = droppedItemSlot.item;
        thisItemSlot.currentStack = droppedItemSlot.currentStack;
        droppedItemSlot.Clear();
    }

    protected virtual void SwapItems(PointerEventData eventData)
    {
        ItemHolder.ItemSlot tempSlot = new ItemHolder.ItemSlot(thisItemSlot.item, thisItemSlot.currentStack);

        thisItemSlot.item = droppedItemSlot.item;
        thisItemSlot.currentStack = droppedItemSlot.currentStack;

        droppedItemSlot.item = tempSlot.item;
        droppedItemSlot.currentStack = tempSlot.currentStack;
    }

    public void RefreshItemIcon()
    {
        if (thisItemSlot.item != null)
        {
            icon.GetComponent<Image>().sprite = thisItemSlot.item.icon;
            if (thisItemSlot.currentStack > 1)
            {
                stack.text = "x" + thisItemSlot.currentStack;
            }
            else
            {
                stack.text = "";
            }
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
    }
}
