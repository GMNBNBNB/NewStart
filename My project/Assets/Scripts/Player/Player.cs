using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonobehavior<Player>
{
    public float inputX, inputY;
    public ToolEffect toolEffect = ToolEffect.none;
    public bool isWalking, isRuning, isIdle, isUsingToolRight,
     isUsingToolLeft, isUsingToolUp, isUsingToolDown,
     isLifingToolRight, isLifingToolLeft, isLifingToolUp, isLifingToolDown,
     isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
     isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
     idleUp, idleDwon, idleLeft, idleRight;

    private new Rigidbody2D rigidbody2D;

    private Direction playerDirection;

    private float movementSpeed;

    private float _playerInput;

    private bool _playerInputDisabled = false;

    public bool PlayerInputDisabled { get => _playerInputDisabled; set => _playerInputDisabled = value; }

    protected override void Awake()
    {
        base.Awake();

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #region Player Input
        ResetAnimationTriggers();

        PlayerMovementInput();

        PlayerWalkInput();

        EventHandler.CallMovementEvent(inputX, inputY,
               isWalking, isRuning, isIdle, isUsingToolRight,
               isUsingToolLeft, isUsingToolUp, isUsingToolDown,
               toolEffect,
               isLifingToolRight, isLifingToolLeft, isLifingToolUp, isLifingToolDown,
               isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
               isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
               false, false, false, false);

        #endregion
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        Vector2 move = new Vector2(inputX * movementSpeed * Time.deltaTime, inputY * movementSpeed * Time.deltaTime);
        rigidbody2D.MovePosition(rigidbody2D.position + move);
    }

    private void PlayerMovementInput()
    {
        inputY = Input.GetAxisRaw("Vertical");
        inputX = Input.GetAxisRaw("Horizontal");

        if (inputY != 0 && inputX != 0)
        {
            inputX = inputX * 0.71f;
            inputY = inputY * 0.71f;
        }

        if (inputY != 0 || inputX != 0)
        {
            isRuning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Setting.runningSpeed;

            if (inputX < 0)
            {
                playerDirection = Direction.Left;
            }
            else if (inputX > 0)
            {
                playerDirection = Direction.Right;
            }
            else if(inputY < 0)
            {
                playerDirection = Direction.Down;
            }
            else
            {
                playerDirection = Direction.Up;
            }
        }else if (inputY == 0 && inputX == 0)
        {
            isRuning = false;
            isWalking = false;
            isIdle = true;
        }


    }

    private void ResetAnimationTriggers()
    {
        isUsingToolRight = false;
        isUsingToolLeft = false;
        isUsingToolUp = false;
        isUsingToolDown = false;

        isLifingToolRight = false;
        isLifingToolLeft = false;
        isLifingToolUp = false;
        isLifingToolDown = false;

        isPickingRight = false;
        isPickingLeft = false;
        isPickingUp = false;
        isPickingDown = false;

        isSwingingToolRight = false;
        isSwingingToolLeft = false;
        isSwingingToolUp = false;
        isSwingingToolDown = false;
    }

    private void PlayerWalkInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isRuning = false;
            isWalking = true;
            isIdle = false;
            movementSpeed = Setting.walkingSpeed;
        }
        else
        {
            isRuning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Setting.runningSpeed;
        }

    }
}
