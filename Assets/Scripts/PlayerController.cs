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
    public float JumpForce = 5;
    public float JumpInputDurationMin = 1;
    public float JumpInputDurationMax = 3;

    [Header("Data")]
    public Vector2 CameraInput = Vector2.zero;

    // Components
    Rigidbody _rigidbody;
    PlayerInputs _input;

    // Data
    float _jumpInputTime = 0;

    //public DateTime startTime,endTime;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInputs>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    
    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase is InputActionPhase.Performed)
            _jumpInputTime = Time.time;

        if (callbackContext.phase is InputActionPhase.Canceled)
        {
            float inputDuration = Mathf.Clamp(Time.time - _jumpInputTime, JumpInputDurationMin, JumpInputDurationMax);
            
            Text.text = "Force is " + inputDuration + " now";

            Vector3 direction = (transform.position - Camera.main.transform.position);
            direction = direction.normalized + Vector3.up;
            direction = direction.normalized;

            _rigidbody.AddForce(direction * JumpForce * inputDuration, ForceMode.Impulse);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        CameraInput = context.ReadValue<Vector2>();
    }


    //public int GetSubSeconds(DateTime startTimer, DateTime endTimer)
    //{
    //    TimeSpan startS = new TimeSpan(startTimer.Ticks);

    //    TimeSpan endS = new TimeSpan(endTimer.Ticks);

    //    TimeSpan subT = endS.Subtract(startS).Duration();

      
    //    return (int)subT.TotalSeconds;
    //}

}
