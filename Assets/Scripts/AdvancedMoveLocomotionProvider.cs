using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AdvancedMoveLocomotionProvider : LocomotionProvider
{
    [SerializeField] private bool enable = true;
    [SerializeField, Range(0, 0.1f)] private float amplitude = 0.00125f;
    [SerializeField, Range(0, 30)] private float frequency = 10.0f;
    [SerializeField] private float running_faster_ratio = 1.25f;

    [SerializeField] private Transform cam = null;
    [SerializeField] private Transform camHolder = null;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private InputActionProperty inputAction;
    private ContinuousMoveProviderBase moveProvider;
    
    private float toggleSpeed = 0.5f;
    private Vector3 startPos;

    void Start()
    {
        startPos = cam.localPosition;
        moveProvider = GetComponent<ContinuousMoveProviderBase>();
    }

    private void PlayMotion(Vector3 motion)
    {
        cam.localPosition += motion;
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
        pos.y += Mathf.Sin(Time.time * frequency ) * amplitude ;

        return pos;
    }

    private void CheckMotion()
    {
        float speed = new Vector3(characterController.velocity.x, 0, characterController.velocity.z).magnitude;

        if (speed < toggleSpeed) return;
        if (characterController.isGrounded) return;

        PlayMotion(FootStepMotion());
    }

    private void ResetPosition()
    {
        if (cam.localPosition == startPos) return;
        cam.localPosition = Vector3.Lerp(cam.localPosition, startPos, 1 * Time.deltaTime);
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

        float speed = moveProvider.moveSpeed;

        if (inputAction.action.IsPressed())
        {
            Debug.Log("Running");
            moveProvider.moveSpeed = speed  * running_faster_ratio;
            CheckMotion();
        }
        else
        {
            moveProvider.moveSpeed = speed;
            Debug.Log("Walking");
            Debug.Log(speed);
            CheckMotion();
        }
        ResetPosition();
        cam.LookAt(FocusTarget());
    }
}
