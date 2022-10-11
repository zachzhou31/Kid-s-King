using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGoAndBack : MonoBehaviour
{
    public Vector3 StartPoint, EndPoint;
    public float MoveSpeed;

    bool _moveTo = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            DeskBounceMove();
    }

    void DeskBounceMove()
    {
        if (_moveTo)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, EndPoint, MoveSpeed);
            if (this.transform.position == EndPoint)
            {
                _moveTo = false;
            }
        }

        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, StartPoint, MoveSpeed);
            if (this.transform.position == StartPoint)
            {
                _moveTo = true;
            }
        }
    }
}
