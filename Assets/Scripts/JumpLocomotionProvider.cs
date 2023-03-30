using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class JumpLocomotionProvider : LocomotionProvider
{
    public float jumpSpeed = 3f;
    [SerializeField]
    private InputActionProperty InputActionProperty;
    [SerializeField]
    private CharacterController characterController;

    private Vector3 verticalSpeed = Vector3.zero;
    private bool downwardCollided = false;

    void Update()
    {
        if (characterController.isGrounded || downwardCollided)
        {
            if (InputActionProperty.action.IsPressed())
            {
                verticalSpeed = Vector3.up * jumpSpeed;
            }
            else
            {
                verticalSpeed = Vector3.zero;
            }
        }
        else
        {
            verticalSpeed += Physics.gravity * Time.deltaTime;
        }

        var collisionFlags = characterController.Move(verticalSpeed * Time.deltaTime);
        downwardCollided = (collisionFlags & CollisionFlags.Below) != 0;
    }
}
