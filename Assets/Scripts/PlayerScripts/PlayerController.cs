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
    public Image JumpImage;
    public Vector3 SavePointPosition = new Vector3(-11f,0.6f,-11f);
    public Rigidbody _rigidbody;
    public Vector3 WindSpeed;
    public float ForceEnhance;
    public bool IsJump = false;
    [Header("Data")]
    public Vector2 CameraInput = Vector2.zero;

    // Singleton ����
    public static PlayerController Instance;

    // Components
    

    // Data
    float _jumpInputTime = 0;

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
        if (_rigidbody.velocity.magnitude < 0.2)
        {
            IsJump = true;
            JumpImage.color = Color.green;

        }
            

        ExposureSlider.value = Exposure;
    }

    private void TestExposure()
    {
        if (Exposure > 20)
        {
            ResetPosition();
            Exposure = 0;
            _rigidbody.velocity = Vector3.zero;
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
                JumpImage.color = Color.red;
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
        
                       
    }
             

    

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Carrier")
        {
            this.GetComponent<Rigidbody>().MovePosition(transform.position + collision.collider.GetComponent<GoAndBack>()._direction * (collision.collider.GetComponent<GoAndBack>().MoveSpeed/4) * Time.deltaTime);
            //_rigidbody.AddForce(collision.collider.GetComponent<Rigidbody>().velocity * 10);
            //transform.position = Vector3.MoveTowards(transform.position, collision.collider.transform.position, 5f);
        }
            
    }

    void ResetPosition()
    {
        
        PlayerController.Instance.transform.position = PlayerController.Instance.SavePointPosition;
        PlayerController.Instance.Exposure = 0;
    }

}
