using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerVisualBehavior : MonoBehaviour
{
    [SerializeField] PlayerControls playerControls;
    new SpriteRenderer renderer;
    Animator animator;
    PlayerAnimationState animationState;
    new CapsuleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Sideflip();
        if (playerControls.canJump && Mathf.Abs(playerControls.rBody.velocity.y) < 0.1)
        {
            RunningCheck();
        }
        else
        {
            AirCheck();
        }
        UpdateAnim();
    }

    void Sideflip()
    {
        if (playerControls.rBody.velocity.x > 0.1)
        {
            renderer.flipX = false;
        }
        if (playerControls.rBody.velocity.x < -0.1)
        {
            renderer.flipX = true;
        }
    }

    void RunningCheck()
    {
        if (Mathf.Abs(playerControls.rBody.velocity.x) > 0.1)
        {
            animationState = PlayerAnimationState.Walking;
        }
        else
        {
            animationState = PlayerAnimationState.Idle;
        }
    }

    void AirCheck()
    {
        if (playerControls.justJumped)
        {
            animationState = PlayerAnimationState.Jump;
        }
        else
        {
            animationState = PlayerAnimationState.Airborne;
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
            case (PlayerAnimationState.Jump):
                animator.SetInteger("SelectAnim", 2);
                break;
            case (PlayerAnimationState.Airborne):
                animator.SetInteger("SelectAnim", 3);
                if (playerControls.rBody.velocity.y > 0)
                {
                    animator.SetBool("Falling", false);
                }
                else
                {
                    animator.SetBool("Falling", true);
                }
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
