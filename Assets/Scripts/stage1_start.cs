using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_start : MonoBehaviour
{
    public bool Stage1Start = false;
    public GameObject Students;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerBall")
        {
            Stage1Start = true;
            Invoke("StudentShowUp", 5f);
        }
    }

    private void StudentShowUp()
    {
        Students.SetActive(true);
    }
}
