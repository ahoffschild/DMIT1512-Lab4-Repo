using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    Vector2 moveVector;
    PlayerInput input;
    public Rigidbody2D rBody;
    public bool canJump;
    [SerializeField] float lrSpeed;
    [SerializeField] float speedCap;
    [SerializeField] float jumpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        moveVector = Vector2.zero;
    }

    //TODO: Update 

    // Update is called once per frame
    void Update()
    {
        rBody.AddForce(lrSpeed * moveVector, ForceMode2D.Force);
        if (rBody.velocity.x > speedCap)
        {
            rBody.velocity = new Vector2(speedCap, rBody.velocity.y);
        }
        if (rBody.velocity.x < -1 * speedCap)
        {
            rBody.velocity = new Vector2(-1 * speedCap, rBody.velocity.y);
        }
        Debug.Log(rBody.velocity.x);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame() && canJump)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, 0);
            rBody.AddForce(jumpSpeed * Vector2.up, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stage" && rBody.velocity.y == 0)
        {
            canJump = true;
        }
    }
}
