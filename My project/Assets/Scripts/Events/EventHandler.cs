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

    // Advance game hour
    public static event Action<int, Season, int, string, int, int, int> AdvanceGameMinuteEvent;
    public static void CallAdvanceGameMinuteEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameMinuteEvent != null)
        {
            AdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    // Advance game hour
    public static event Action<int, Season, int, string, int, int, int> AdvanceGameHourEvent;
    public static void CallAdvanceGameHourEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameHourEvent != null)
        {
            AdvanceGameHourEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }
    
    // Advance game day
    public static event Action<int, Season, int, string, int, int, int> AdvanceGameDayEvent;
    public static void CallAdvanceGameDayEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameDayEvent != null)
        {
            AdvanceGameDayEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    //Advance game season
    public static event Action<int, Season, int, string, int, int, int> AdvanceGameSeasonEvent;
    public static void CallAdvanceGameSeasonEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameSeasonEvent != null)
        {
            AdvanceGameSeasonEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    //Advance game year
    public static event Action<int, Season, int, string, int, int, int> AdvanceGameYearEvent;
    public static void CallAdvanceGameYearEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        if (AdvanceGameYearEvent != null)
        {
            AdvanceGameYearEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

}