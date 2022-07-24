using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject invisibleCup;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            invisibleCup.SetActive(true);
            Destroy(this);
        }
    }
}
