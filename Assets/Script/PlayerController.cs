using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    public Transform moveStandardTransform;
    public Transform forward;
    public InputActionAsset inputActionAsset;
    public Animator animator;
    public float speed = 3;
    public float runspeed = 5;
    public float TurnSpeed = 70;
    public float smoothValue = 0.1f;

    Rigidbody PlayerRigidbody;
    void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        handmove();
        movement();
        turnmove();
    }

    void movement()
    {
        Vector3 PinchPosition = inputActionAsset.actionMaps[3].actions[5].ReadValue<Vector2>();
        forward.eulerAngles = new Vector3(0, moveStandardTransform.eulerAngles.y, 0);
        Vector3 movevector = forward.right * PinchPosition.x + forward.forward * PinchPosition.y;
        if (inputActionAsset.actionMaps[2].actions[4].IsPressed())
        {
            PlayerRigidbody.MovePosition(this.transform.position + movevector * runspeed * Time.deltaTime);
        }
        else
        {
            PlayerRigidbody.MovePosition(this.transform.position + movevector * speed * Time.deltaTime);
        }
    }
    void handmove()
    {
        if (inputActionAsset.actionMaps[2].actions[0].IsPressed())
        {
            animator.SetBool("LeftHandGrab", true);
        }
        else
        {
            animator.SetBool("LeftHandGrab", false);
        }

        if (inputActionAsset.actionMaps[5].actions[0].IsPressed())
        {
            animator.SetBool("RightHandGrab", true);
        }
        else
        {
            animator.SetBool("RightHandGrab", false);
        }
    }
    void turnmove()
    {
        float rightPinch = inputActionAsset.actionMaps[6].actions[5].ReadValue<Vector2>().x;

        var targetRotation = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + TurnSpeed * rightPinch, this.transform.eulerAngles.z);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(targetRotation), smoothValue);
 
    }
}
