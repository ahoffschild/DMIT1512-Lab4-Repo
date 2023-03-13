using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    Vector2 moveVector;
    PlayerInput input;
    Rigidbody2D rBody;
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
        rBody.AddForce(lrSpeed * moveVector, ForceMode2D.Force);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.action.WasPerformedThisFrame())
        {
            rBody.AddForce(jumpSpeed * Vector2.up, ForceMode2D.Impulse);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }
}
