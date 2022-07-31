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
        if (other.name == "Boss")
        {

            BossMove.Instance.Health -= 25;
            Destroy(gameObject);
        }
            
    }
}
