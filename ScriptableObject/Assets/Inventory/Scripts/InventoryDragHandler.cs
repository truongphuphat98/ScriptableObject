using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDragHandler : ItemDragHandler
{
    private InventoryHandler InventoryHandler;





    protected override void Start()
    {
        base.Start();
        InventoryHandler = InventoryHandler.instance;
        itemSlot = InventoryHandler.currentInventory.itemSlots[slotIndex];
    }

    protected override void DropFromSlot()
    {
        //InventoryHandler.currentInventory.DropItem(itemSlot);
    }
}
