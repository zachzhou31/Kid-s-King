using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Text Text;

    [Header("Configs")]
    public float Exposure = 0;
    public float JumpForce = 5;
    public float JumpInputDurationMin = 1;
    public float JumpInputDurationMax = 3;
    public Vector3 SavePointPosition = new Vector3(-11f,0.6f,-11f);
    

    [Header("Data")]
    public Vector2 CameraInput = Vector2.zero;

    // Singleton µ¥Àý
    public static PlayerController Instance;

    // Components
    Rigidbody _rigidbody;

    // Data
    float _jumpInputTime = 0;
    bool _isJump = false;

    private void Awake()
    {
        if (!Instance) Instance = this;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TestExposure();
        if (_rigidbody.velocity.magnitude < 0.1)
            _isJump = true;


    }

    private void TestExposure()
    {
        if (Exposure > 20)
        {
            transform.position = SavePointPosition;
            Exposure = 0;
        }
            
    }

    

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (_isJump)
        {
            if (callbackContext.phase is InputActionPhase.Performed)

                _jumpInputTime = Time.time;

            if (callbackContext.phase is InputActionPhase.Canceled)
            {
                float inputDuration;
                if (_jumpInputTime == 0)
                    inputDuration = 1;
                else
                    inputDuration = Mathf.Clamp(Time.time - _jumpInputTime, JumpInputDurationMin, JumpInputDurationMax);

                Text.text = "Force is " + inputDuration + " now";

                Vector3 direction = (transform.position - Camera.main.transform.position);
                direction = direction.normalized + Vector3.up;
                direction = direction.normalized;

                _rigidbody.AddForce(direction * JumpForce * inputDuration, ForceMode.Impulse);

                _isJump = false;
            }
        }

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        CameraInput = context.ReadValue<Vector2>();
    }



}
