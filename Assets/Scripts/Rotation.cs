using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float RotationSpeed = 2.0f;
    public PlayerController Player;
    public float _direction = 1;
    public LayerMask SightMask;
    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 20 * Time.deltaTime * _direction, 0);

        if (transform.rotation.eulerAngles.y <=  2 )     
            _direction = 1;          
        else if(transform.rotation.eulerAngles.y >= 90 )
            _direction = -1;

        RayCastCollid();
        

    }

    void RayCastCollid()
    {
        RaycastHit hitInfo;

        if(Physics.Raycast(transform.position,transform.right,out hitInfo,10000, SightMask))
        {
            Debug.Log(hitInfo.collider.name);
            if(hitInfo.collider.name == "Player")
                Player.GetComponent<PlayerController>().Exposure += 1;
            
        }
    }
}
