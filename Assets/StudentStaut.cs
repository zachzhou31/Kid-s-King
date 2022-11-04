using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentStaut : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Teacher;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Teacher.transform.position.z <= 46.2) && (Teacher.transform.position.x == -52))
            this.GetComponent<AudioSource>().enabled = true;
        else
            this.GetComponent<AudioSource>().enabled = false;
    }
}
