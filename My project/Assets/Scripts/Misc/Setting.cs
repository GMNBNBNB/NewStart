using UnityEngine;

public static class Setting
{
    // Item fading 
    public const float fadeInSecond = 0.25f;
    public const float fadeOutSecond = 0.35f;
    public const float targetAlpha = 0.45f;

    //Inventory
    public static int playerInitialInventoryCapacity = 24;
    public static int playerMaximumInventoryCapacity = 48;
    
    public static int inputX,inputY,
        isWalking, isRuning, isIdle, isUsingToolRight,
        isUsingToolLeft, isUsingToolUp, isUsingToolDown,
        toolEffect,
        isLifingToolRight, isLifingToolLeft, isLifingToolUp, isLifingToolDown,
        isPickingRight, isPickingLeft, isPickingUp, isPickingDwon,
        isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDwon,
        isWalkUp, isWalkDown, idleLeft, idleRight;

    // walk speed
    public const float walkingSpeed = 2.666f;
    public const float runningSpeed = 5.333f;

    //Time System
    public const float secondsPerGameSecond = 0.012f;

    static Setting()
    {
        inputX = Animator.StringToHash("inputX");
        inputY = Animator.StringToHash("inputY");
        isWalking = Animator.StringToHash("isWalking");
        isRuning = Animator.StringToHash("isRuning");
        isIdle = Animator.StringToHash("isIdle");
        isUsingToolRight = Animator.StringToHash("isUsingToolRight");
        isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
        isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        isUsingToolDown = Animator.StringToHash("isUsingToolDown");
        toolEffect = Animator.StringToHash("toolEffect");
        isLifingToolRight = Animator.StringToHash("isLifingToolRight");
        isLifingToolLeft = Animator.StringToHash("isLifingToolLeft");
        isLifingToolUp = Animator.StringToHash("isLifingToolUp");
        isLifingToolDown = Animator.StringToHash("isLifingToolDown");
        isPickingRight = Animator.StringToHash("isPickingRight");
        isPickingLeft = Animator.StringToHash("isPickingLeft");
        isPickingUp = Animator.StringToHash("isPickingUp");
        isPickingDwon = Animator.StringToHash("isPickingDwon");
        isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");
        isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft");
        isSwingingToolUp = Animator.StringToHash("isSwingingToolUp");
        isSwingingToolDwon = Animator.StringToHash("isSwingingToolDwon");

        isWalkUp = Animator.StringToHash("isWalkUp");
        isWalkDown = Animator.StringToHash("isWalkDown");
        idleLeft = Animator.StringToHash("idleLeft");
        idleRight = Animator.StringToHash("idleRight");

    }

}
