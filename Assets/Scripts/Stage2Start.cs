using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Start : MonoBehaviour
{
    // Start is called before the first frame update
    public bool StageTwoStart = false;
    public GameObject InvisibleCup;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StageTwoStart)
        {
            InvisibleCup.SetActive(true);
            Destroy(gameObject);
        }
            

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            StageTwoStart = true;
        }
    }
}
