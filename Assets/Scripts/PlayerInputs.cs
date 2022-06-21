using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public bool jump;
	// Start is called before the first frame update
	public void OnJump(InputValue value)
	{
		JumpInput(value.isPressed);
	}

	public void JumpInput(bool newJumpState)
	{
		jump = newJumpState;
	}
}
