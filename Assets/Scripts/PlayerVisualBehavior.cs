using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerVisualBehavior : MonoBehaviour
{
    [SerializeField] PlayerControls playerControls;
    SpriteRenderer renderer;
    Animator animator;
    PlayerAnimationState animationState;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Sideflip();
        if (playerControls.canJump == true && playerControls.rBody.velocity.y == 0)
        {
            RunningCheck();
        }
        UpdateAnim();
    }

    void Sideflip()
    {
        if (playerControls.rBody.velocity.x > 0)
        {
            renderer.flipX = false;
        }
        if (playerControls.rBody.velocity.x < 0)
        {
            renderer.flipX = true;
        }
    }

    void RunningCheck()
    {
        if (playerControls.rBody.velocity.x != 0)
        {
            animationState = PlayerAnimationState.Walking;
        }
        else
        {
            animationState = PlayerAnimationState.Idle;
        }
    }

    void UpdateAnim()
    {
        switch(animationState)
        {
            case (PlayerAnimationState.Idle):
                animator.SetInteger("SelectAnim", 0);
                break;
            case (PlayerAnimationState.Walking):
                animator.SetInteger("SelectAnim", 1);
                break;
            default:
                animator.SetInteger("SelectAnim", 0);
                break;
        }

    }

    public enum PlayerAnimationState
    {
        Idle,
        Walking,
        Jump,
        Airborne
    }
}
