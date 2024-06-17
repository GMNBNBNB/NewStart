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
     isWalkUp, isWalkDown, idleLeft, idleRight;

    private Camera mainCamera;

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

        mainCamera = Camera.main;
    }

    private void Update()
    {
        #region Player Input
        ResetAnimationTriggers();

        PlayerMovementInput();

        PlayerWalkInput();

        PlayerTestTimeInput();

        EventHandler.CallMovementEvent(inputX, inputY,
               isWalking, isRuning, isIdle, isUsingToolRight,
               isUsingToolLeft, isUsingToolUp, isUsingToolDown,
               toolEffect,
               isLifingToolRight, isLifingToolLeft, isLifingToolUp, isLifingToolDown,
               isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
               isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
               isWalkUp, isWalkDown, false, false);

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
            isWalking = true;
            isIdle = false;
            movementSpeed = Setting.runningSpeed;

            if(inputY < 0)
            {
                isWalkDown = true;
                isWalking = false;
            }
            else if(inputY > 0)
            {
                isWalkUp = true;
                isWalking = false;
            }
        }else if (inputY == 0 && inputX == 0)
        {
            isRuning = false;
            isWalking = false;
            isWalkDown = false;
            isWalkUp = false;
            isIdle = true;
        }
    }

    private void ResetAnimationTriggers()
    {
        isWalkDown = false;
        isWalkUp = false;
        isRuning = false;
        isWalking = false;
        isIdle = true;

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
            isRuning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Setting.runningSpeed;
        }
        else
        {
            movementSpeed = Setting.walkingSpeed;
        }
    }

    // Test Time
    private void PlayerTestTimeInput()
    {
        if (Input.GetKey(KeyCode.T))
        {
            TimeManager.Instance.TestAdvanceGameMinute();
        }

        if (Input.GetKey(KeyCode.G))
        {
            TimeManager.Instance.TestAdvanceGameDay();
        }
    }

    public Vector3 GetPlayerViewportPosition()
    {
        return mainCamera.WorldToViewportPoint(transform.position);
    }

}
