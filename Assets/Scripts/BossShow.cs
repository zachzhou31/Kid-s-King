using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BossPreFab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "PlayerBall")
        {
            BossPreFab.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
