using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRoot : MonoBehaviour
{
    public PlayerController Player;
    public float HorizontalSpeed = 1;
    public float CameraInputLerpSpeed = 1;
    Vector2 lastCameraInput = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follow
        transform.position = Player.transform.position;

        // Aim
        Vector2 currentCameraInput = Player.CameraInput;
        Vector2 cameraInput = Vector2.Lerp(lastCameraInput, currentCameraInput, CameraInputLerpSpeed * Time.deltaTime);
        lastCameraInput = currentCameraInput;

        transform.Rotate(Vector3.up * cameraInput.x * Time.deltaTime * HorizontalSpeed);
    }
}
