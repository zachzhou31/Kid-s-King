using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastStageStart : MonoBehaviour
{
    private float _jumpForceOrigin;
    // Start is called before the first frame update
    void Start()
    {
        _jumpForceOrigin = PlayerController.Instance.JumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerBall")
            PlayerController.Instance.JumpForce = _jumpForceOrigin;
    }
}
