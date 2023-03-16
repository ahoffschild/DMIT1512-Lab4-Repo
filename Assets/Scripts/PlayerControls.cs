using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    Vector2 moveVector;
    PlayerInput input;
    Rigidbody2D rBody;
    public bool canJump;
    [SerializeField] float lrSpeed;
    [SerializeField] float jumpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        moveVector = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //rBody.AddForce(lrSpeed * moveVector, ForceMode2D.Force);
        rBody.velocity = new Vector2((lrSpeed * moveVector.x), rBody.velocity.y);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame() && canJump)
        {
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
