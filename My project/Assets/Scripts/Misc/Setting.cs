using UnityEngine;

public static class Setting
{
    public static int inputX,inputY,
        isWalking, isRuning, isIdle, isUsingToolRight,
        isUsingToolLeft, isUsingToolUp, isUsingToolDown,
        toolEffect,
        isLifingToolRight, isLifingToolLeft, isLifingToolUp, isLifingToolDown,
        isPickingRight, isPickingLeft, isPickingUp, isPickingDwon,
        isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDwon,
        idleUp, idleDwon, idleLeft, idleRight;

    public const float walkingSpeed = 5.333f;
    public const float runningSpeed = 2.666f;

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

        idleUp = Animator.StringToHash("idleUp");
        idleDwon = Animator.StringToHash("idleDwon");
        idleLeft = Animator.StringToHash("idleLeft");
        idleRight = Animator.StringToHash("idleRight");

    }

}
