using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotation : MonoBehaviour
{
    public Quaternion Rotation1 = Quaternion.Euler(0f,-30f,0f);
    public Quaternion Rotation2 = Quaternion.Euler(0f, -130f, 0f);
    public float RotationTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationTime += Time.deltaTime;
        if (RotationTime % 10 <= 5)
            transform.rotation = Quaternion.Lerp(transform.rotation, Rotation1, Time.deltaTime);
        else
            transform.rotation = Quaternion.Lerp(transform.rotation, Rotation2, Time.deltaTime);
    }
}
