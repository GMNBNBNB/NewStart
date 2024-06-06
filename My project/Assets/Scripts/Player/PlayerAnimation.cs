using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public float inputX, inputY;
    public ToolEffect toolEffect;
    public bool isWalking, isRuning, isIdle, isUsingToolRight,
     isUsingToolLeft, isUsingToolUp, isUsingToolDown,
     isLifingToolRight, isLifingToolLeft, isLifingToolUp, isLifingToolDown,
     isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
     isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
     isWalkUp, isWalkDown, idleLeft, idleRight;

    public void Update()
    {
        EventHandler.CallMovementEvent(inputX, inputY,
               isWalking, isRuning, isIdle, isUsingToolRight,
               isUsingToolLeft, isUsingToolUp, isUsingToolDown,
               toolEffect,
               isLifingToolRight, isLifingToolLeft, isLifingToolUp, isLifingToolDown,
               isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
               isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
               isWalkUp, isWalkDown, idleLeft, idleRight);
    }
}
