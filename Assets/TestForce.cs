using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestForce : MonoBehaviour
{
    
    public Text tp;
    // Start is called before the first frame update
    void Start()
    {
        tp = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            tp.text = "Update";
    }
}
