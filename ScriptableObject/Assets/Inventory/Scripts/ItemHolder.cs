﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : ScriptableObject
{

    public ItemSlot[] itemSlots;

    [System.Serializable]
    public class ItemSlot
    {
        public Item item;
        public int currentStack;

        public ItemSlot(Item setItem, int stack)
        {
            item = setItem;
            currentStack = stack;
        }

        public void Clear()
        {
            item = null;
            currentStack = 0;
        }

        public void SetNewItem(Item newItem)
        {
            item = newItem;
            currentStack = 1;
        }
    }

    private bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == item)
            {
                if (itemSlots[i].currentStack < itemSlots[i].item.maxStack)
                {
                    itemSlots[i].currentStack++;
                    //Update UI
                    return true;
                }
            }
        }

        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].SetNewItem(item);
            //Update UI
            return true;
        }
        return false;
    }
}
