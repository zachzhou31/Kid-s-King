using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    public GameObject Point1, Point2, Point3, Point4, Point5;
    // Start is called before the first frame update
    private int _index = 0;
    private Vector3 _nextPosition;
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
            _nextPosition = this.nextPosition(_index);
            if (_nextPosition != Vector3.zero)
                Invoke("CupRun", 2);
            else
                Destroy(this);
            _index += 1;
        }
            
    }


    public Vector3 nextPosition(int index)
    {
        switch (index) {
            case 0:
                return Point1.transform.position;
            case 1:
                return Point2.transform.position;
            case 2:
                return Point3.transform.position;
            case 3:
                return Point4.transform.position;
            case 4:
                return Point5.transform.position;
            default:
                return Vector3.zero;

        };

    }

    private void CupRun()
    {
        this.transform.position = _nextPosition;
    }
}
