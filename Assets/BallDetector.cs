using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ball;
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
        if (other.name == "Player")
            Ball.GetComponent<chasePlayer>().enabled = true;

    }
}
