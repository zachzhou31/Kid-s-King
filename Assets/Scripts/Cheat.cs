using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    // Start is called before the first frame update
    public bool cheatButton = false;
    public GameObject cheatObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cheatButton)
        {
            this.transform.position = cheatObject.transform.position;
            cheatButton = false;
        }

    }
}
