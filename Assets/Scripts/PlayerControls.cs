using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    Vector2 moveVector;
    public PlayerBehavior playerBehavior;
    public Rigidbody2D rBody;
    public bool canJump;
    public bool justJumped;
    private int jumpOff;
    [SerializeField] Collider2D groundCheck;
    [SerializeField] float lrSpeed;
    [SerializeField] float speedCap;
    [SerializeField] float jumpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerBehavior = GetComponent<PlayerBehavior>();
        rBody = GetComponent<Rigidbody2D>();
        moveVector = Vector2.zero;
        jumpOff = 1;
    }

    //TODO: Update 

    // Update is called once per frame
    void Update()
    {
        JumpChecks();
        if (moveVector.x != 0)
        {
            rBody.AddForce(lrSpeed * moveVector, ForceMode2D.Force);
        }
        //If not pressed, decelerates faster
        else
        {
            rBody.velocity = new Vector2(rBody.velocity.x * 0.99f, rBody.velocity.y);
        }

        if (Mathf.Abs(rBody.velocity.x) > speedCap)
        {
            rBody.velocity = new Vector2(rBody.velocity.normalized.x * speedCap, rBody.velocity.y);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame() && canJump)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, 0);
            rBody.AddForce(jumpSpeed * Vector2.up, ForceMode2D.Impulse);
            canJump = false;
            justJumped = true;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    public void OnReset(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
        {
            playerBehavior.CheckpointRespawn();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
		//if (collision.gameObject.tag == "Stage" && collision.otherCollider == groundCheck && Mathf.Abs(rBody.velocity.y) < 0.1)
		//{
		//	canJump = true;
		//}
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Stage" && Mathf.Abs(rBody.velocity.y) < 0.1)
		{
			canJump = true;
		}
	}

    public void JumpChecks()
    {
        if (justJumped == true)
        {
            if (jumpOff == 0)
            {
                justJumped = false;
                jumpOff = 1;
            }
            else
            {
                jumpOff--;
            }
        }
    }
}
