using UnityEngine;
using System.Collections.Generic;

public class Player : SingletonMonobehavior<Player>
{
    public AnimationOverrides animationOverrides;

    public float inputX, inputY;
    public ToolEffect toolEffect = ToolEffect.none;
    public bool isWalking, isRuning, isIdle, isUsingToolRight,
     isUsingToolLeft, isUsingToolUp, isUsingToolDown,
     isLifingToolRight, isLifingToolLeft, isLifingToolUp, isLifingToolDown,
     isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
     isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
     isWalkUp, isWalkDown, isCarrying = false, idleRight;

    private Camera mainCamera;

    private new Rigidbody2D rigidbody2D;

    private Direction playerDirection;

    private List<CharacterAttribute> characterAttributeCustomisationList;
    private float movementSpeed;

    [Tooltip("Should be populated in the prefab with equipped item sprite renderer")]
    [SerializeField] private SpriteRenderer equippedItemSpriteRenderer = null;

    // Player attributes that can be swapped
    private CharacterAttribute armsCharacterAttribute;
    private CharacterAttribute toolCharacterAttribute;


    private float _playerInput;

    private bool _playerInputDisabled = false;

    public bool PlayerInputDisabled { get => _playerInputDisabled; set => _playerInputDisabled = value; }

    protected override void Awake()
    {
        base.Awake();

        rigidbody2D = GetComponent<Rigidbody2D>();

        animationOverrides = GetComponentInChildren<AnimationOverrides>();

        // Initialize swappable character attributes
        armsCharacterAttribute = new CharacterAttribute(CharacterPartAnimator.arms, PartVariantColor.none, PartVariantType.none);

        // initialize character attribute list
        characterAttributeCustomisationList = new List<CharacterAttribute>();

        mainCamera = Camera.main;
    }

    private void Update()
    {
        #region Player Input

        if (!PlayerInputDisabled)
        {
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
                   isWalkUp, isWalkDown, isCarrying, false);
        }

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

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneControllerManager.Instance.FadeAndLoadScene(SceneName.Scene1_Farm.ToString(),transform.position);
        }

    }
    private void ResetMovement()
    {
        inputX = 0f;
        inputY = 0f;
        isRuning = false;
        isWalking = false;
        isIdle = true;
    }

    public void DisablePlayerInputAndResetMovement()
    {
        DisablePlayerInput();
        ResetMovement();

        EventHandler.CallMovementEvent(inputX, inputY,
                   isWalking, isRuning, isIdle, isUsingToolRight,
                   isUsingToolLeft, isUsingToolUp, isUsingToolDown,
                   toolEffect,
                   isLifingToolRight, isLifingToolLeft, isLifingToolUp, isLifingToolDown,
                   isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
                   isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
                   isWalkUp, isWalkDown, isCarrying, false);
    }

    public void DisablePlayerInput()
    {
        PlayerInputDisabled = true;
    }

    public void EnablePlayerInput()
    {
        PlayerInputDisabled = false;
    }

    public void ClearCarriedItem()
    {
        equippedItemSpriteRenderer.sprite = null;
        equippedItemSpriteRenderer.color = new Color(1f, 1f, 1f, 0f);

        // Apply base character arms customisation
        armsCharacterAttribute.partVariantType = PartVariantType.none;
        characterAttributeCustomisationList.Clear();
        characterAttributeCustomisationList.Add(armsCharacterAttribute);
        animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

        isCarrying = false;
    }

    public void ShowCarriedItem(int itemCode)
    {
        ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(itemCode);
        if (itemDetails != null)
        {
            equippedItemSpriteRenderer.sprite = itemDetails.itemSprite;
            equippedItemSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);

            // Apply 'carry' character arms customisation
            armsCharacterAttribute.partVariantType = PartVariantType.carry;
            characterAttributeCustomisationList.Clear();
            characterAttributeCustomisationList.Add(armsCharacterAttribute);
            animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

            isCarrying = true;
        }
    }


    public Vector3 GetPlayerViewportPosition()
    {
        return mainCamera.WorldToViewportPoint(transform.position);
    }

}
