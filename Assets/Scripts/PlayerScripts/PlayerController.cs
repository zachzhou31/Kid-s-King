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
    public Text TextSubtitle;

    public Slider ExposureSlider;

    [Header("Configs")]
    public float Exposure = 0;
    public float JumpForce = 5;
    public float JumpInputDurationMin = 1;
    public float JumpInputDurationMax = 3;
    public Vector3 SavePointPosition = new Vector3(-11f,0.6f,-11f);
    public Rigidbody _rigidbody;
    public Vector3 WindSpeed;
    public bool IsJump = false;
    [Header("Data")]
    public Vector2 CameraInput = Vector2.zero;

    // Singleton µ¥Àý
    public static PlayerController Instance;

    // Components
    

    // Data
    float _jumpInputTime = 0;
    int _cupCollect = 0;
    
    float _waitTime;

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
            IsJump = true;

        ExposureSlider.value = Exposure;
    }

    private void TestExposure()
    {
        if (Exposure > 20)
        {
            ResetPosition();
            Exposure = 0;
        }
            
    }

    

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (IsJump)
        {
            if (callbackContext.phase is InputActionPhase.Started)

                _jumpInputTime = Time.time;

            if (callbackContext.phase is InputActionPhase.Canceled)
            {
                float inputDuration;
                if (_jumpInputTime == 0)
                    inputDuration = 1;
                else
                    inputDuration = Mathf.Clamp(Time.time - _jumpInputTime, JumpInputDurationMin, JumpInputDurationMax);

                

                Vector3 direction = (transform.position - Camera.main.transform.position);
                direction = direction.normalized + Vector3.up;
                direction = direction.normalized;

                _rigidbody.AddForce(direction * JumpForce * inputDuration, ForceMode.Impulse);
                TextSubtitle.text = "Force is " + inputDuration + " now";
                IsJump = false;
            }
        }

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        CameraInput = context.ReadValue<Vector2>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
            Invoke("ResetPosition", 1f);

        if (collision.collider.tag == "Cup")
            _cupCollect += 1;
   
           
    }

    void ResetPosition()
    {
        PlayerController.Instance.transform.position = PlayerController.Instance.SavePointPosition;
    }

}
