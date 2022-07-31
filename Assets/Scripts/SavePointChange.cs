using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointChange : MonoBehaviour
{
    public GameObject Player;
    public GameObject SavePoint;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.GetComponent<PlayerController>().SavePointPosition = transform.position;
            Destroy(SavePoint.gameObject);
        }
            
    }
}
