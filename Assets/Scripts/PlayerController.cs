using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PlayerInputs _input;
    public Rigidbody rg;
    public Transform tf;
    public int addF = 5;
    public bool _ground;
    public bool _jump = false;
    public Vector2 m_Camera = Vector2.zero;
    public Text tx;

    public DateTime startTime,endTime;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInputs>();
        rg = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        tx = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    
    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.phase is InputActionPhase.Performed)
            startTime = DateTime.Now;

        if (callbackContext.phase is InputActionPhase.Canceled)
        {
            endTime = DateTime.Now;
            addF = GetSubSeconds(startTime, endTime);
            addF = addF % 3;
            tx.text = "Force is " + addF + "now";
            rg.AddForce(new Vector3(tf.forward.x, 1, 0) * addF * 5, ForceMode.Impulse);
        }


           
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        m_Camera = context.ReadValue<Vector2>();
        tf.Rotate(new Vector3(0, m_Camera.x, 0));
    }


    public int GetSubSeconds(DateTime startTimer, DateTime endTimer)
    {
        TimeSpan startS = new TimeSpan(startTimer.Ticks);

        TimeSpan endS = new TimeSpan(endTimer.Ticks);

        TimeSpan subT = endS.Subtract(startS).Duration();

      
        return (int)subT.TotalSeconds;
    }

}
