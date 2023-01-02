using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Tank;
    public float Force;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerBall")
            Tank.GetComponent<Rigidbody>().AddForce(Vector3.forward * Force);

    }
}
