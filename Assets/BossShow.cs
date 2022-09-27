using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BossPreFab,Ground;
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
            BossPreFab.SetActive(true);
            Ground.tag = "Untagged";
            this.gameObject.SetActive(false);
        }
    }
}
