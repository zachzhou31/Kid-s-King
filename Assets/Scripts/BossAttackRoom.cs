using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackRoom : MonoBehaviour
{
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
        if (other.tag == "Boss")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            BossMove.Instance.Health -= 25;
            this.gameObject.SetActive(false);
        }
            
    }
}
