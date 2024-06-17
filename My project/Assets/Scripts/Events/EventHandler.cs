using System;
using System.Collections.Generic;


public delegate void MovementDelegate(float inputX, float inputY,
    bool isWalking, bool isRuning, bool isIdle, bool isUsingToolRight,
    bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    ToolEffect toolEffect,
    bool isLifingToolRight, bool isLifingToolLeft, bool isLifingToolUp, bool isLifingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDwon,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDwon,
    bool idleUp, bool idleDwon, bool idleLeft, bool idleRight
    );


public static class EventHandler
{
    //Inventory Updated Event
    public static event Action<InventoryLocation, List<InventoryItem>> InventoryUpdatedEvent;

    public static void CallInventoryUpdatedEvent(InventoryLocation inventoryLocation, List<InventoryItem> inventoryItem)
    {
        if (InventoryUpdatedEvent != null)
        {
            InventoryUpdatedEvent(inventoryLocation, inventoryItem);
        }

    }

    //Movement Event

    public static event MovementDelegate MovementEvent;

    //Movement Event Call For Publishers
    public static void CallMovementEvent(float inputX, float inputY,
    bool isWalking, bool isRuning, bool isIdle, bool isUsingToolRight,
    bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    ToolEffect toolEffect,
    bool isLifingToolRight, bool isLifingToolLeft, bool isLifingToolUp, bool isLifingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDwon,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDwon,
    bool idleUp, bool idleDwon, bool idleLeft, bool idleRight)
    {
        if (MovementEvent != null)
        {
            MovementEvent(inputX,inputY,
                isWalking,isRuning,isIdle,isUsingToolRight,
                isUsingToolLeft,isUsingToolUp,isUsingToolDown,
                toolEffect,
                isLifingToolRight,isLifingToolLeft,isLifingToolUp,isLifingToolDown,
                isPickingRight,isPickingLeft,isPickingUp,isPickingDwon,
                isSwingingToolRight,isSwingingToolLeft,isSwingingToolUp,isSwingingToolDwon,
                idleUp,idleDwon,idleLeft,idleRight);
        }
    }

}