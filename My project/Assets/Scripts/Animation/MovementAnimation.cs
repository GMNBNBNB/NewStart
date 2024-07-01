using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventHandler.MovementEvent += SetAnimationParameters;
    }

    private void OnDisable()
    {
        EventHandler.MovementEvent -= SetAnimationParameters;
    }

    private void SetAnimationParameters(float inputX, float inputY, bool isWalking, bool isRuning, bool isIdle,
        bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown, 
        ToolEffect toolEffect, bool isLifingToolRight, bool isLifingToolLeft, bool isLifingToolUp, 
        bool isLifingToolDown, bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDwon, 
        bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDwon, 
        bool isWalkUp, bool isWalkDown, bool isCarrying, bool idleRight)
    {
        animator.SetBool(Setting.isCarrying, isCarrying);
        animator.SetFloat(Setting.inputX, inputX);
        animator.SetFloat(Setting.inputY, inputY);
        animator.SetBool(Setting.isWalking, isWalking);
        animator.SetBool(Setting.isRuning, isRuning);
        animator.SetBool(Setting.isIdle, isIdle);
        animator.SetBool(Setting.isWalkUp, isWalkUp);
        animator.SetBool(Setting.isWalkDown, isWalkDown);

        animator.SetInteger(Setting.toolEffect, (int)toolEffect);
        if (isUsingToolRight)
            animator.SetTrigger(Setting.isUsingToolRight);
        if (isUsingToolLeft)
            animator.SetTrigger(Setting.isUsingToolLeft);
        if (isUsingToolUp)
            animator.SetTrigger(Setting.isUsingToolUp);
        if (isUsingToolDown)
            animator.SetTrigger(Setting.isUsingToolDown);
        if (isLifingToolRight)
            animator.SetTrigger(Setting.isLifingToolRight);
        if (isLifingToolLeft)
            animator.SetTrigger(Setting.isLifingToolLeft);
        if (isLifingToolUp)
            animator.SetTrigger(Setting.isLifingToolUp);
        if (isLifingToolDown)
            animator.SetTrigger(Setting.isLifingToolDown);
        if (isPickingRight)
            animator.SetTrigger(Setting.isPickingRight);
        if (isPickingLeft)
            animator.SetTrigger(Setting.isPickingLeft);
        if (isPickingUp)
            animator.SetTrigger(Setting.isPickingUp);
        if (isPickingDwon)
            animator.SetTrigger(Setting.isPickingDwon);
        if (isSwingingToolRight)
            animator.SetTrigger(Setting.isSwingingToolRight);
        if (isSwingingToolLeft)
            animator.SetTrigger(Setting.isSwingingToolLeft);
        if (isSwingingToolUp)
            animator.SetTrigger(Setting.isSwingingToolUp);
        if (isSwingingToolDwon)
            animator.SetTrigger(Setting.isSwingingToolDwon);

        if (idleRight)
            animator.SetTrigger(Setting.idleRight);

    }

    private void Update()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
