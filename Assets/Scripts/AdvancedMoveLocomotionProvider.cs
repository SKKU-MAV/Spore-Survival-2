using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AdvancedMoveLocomotionProvider : LocomotionProvider
{
    [SerializeField] private bool enable = true;
    [SerializeField, Range(0, 0.1f)] private float amplitude = 0.015f;
    [SerializeField, Range(0, 30)] private float frequency = 10.0f;
    [SerializeField] private float running_faster_ratio = 1.5f;


    [SerializeField] private Transform cam = null;
    [SerializeField] private Transform camHolder = null;


    [SerializeField] private CharacterController characterController;
    [SerializeField] private InputActionProperty inputActionProperty;


    private float toggleSpeed = 0.5f;
    private Vector3 startPos;
    private Vector3 walkSpeed = Vector3.zero;

    void Start()
    {
        startPos = cam.localPosition;
    }

    private void PlayMotion(Vector3 motion)
    {
        cam.localPosition += motion;
    }

    private Vector3 FootStepMotion(float ratio)
    {
        Vector3 pos = Vector3.zero;
        pos.x += Mathf.Cos(Time.time * frequency / 2 * ratio) * amplitude * 2 * ratio;
        pos.y += Mathf.Sin(Time.time * frequency * ratio) * amplitude * ratio;

        return pos;
    }

    private void CheckMotion(float ratio = 1)
    {

        float speed = new Vector3(characterController.velocity.x, 0, characterController.velocity.z).magnitude;

        if (speed < toggleSpeed) return;
        if (characterController.isGrounded) return;

        PlayMotion(FootStepMotion(ratio));
    }

    private void ResetPosition()
    {
        if (cam.localPosition == startPos) return;
        cam.localPosition = Vector3.Lerp(cam.localPosition, startPos, 5 * Time.deltaTime);
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(characterController.transform.position.x , characterController.transform.position.y + camHolder.localPosition.y, characterController.transform.position.z);
        pos += camHolder.forward * 15.0f;
        return pos;
    }

    void Update()
    {
        if (!enable) return;
        walkSpeed = characterController.velocity;

        if (inputActionProperty.action.IsPressed())
        {
            characterController.Move(walkSpeed * Time.deltaTime * running_faster_ratio);
            CheckMotion(running_faster_ratio);
        }

        else
        {
            characterController.Move(walkSpeed * Time.deltaTime);
            CheckMotion();
        }

        CheckMotion();

        

        ResetPosition();
        cam.LookAt(FocusTarget());

        
    }
}
