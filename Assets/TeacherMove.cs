using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 StartPoint, TurnPoint, EndPoint;
    public float _moveDistancePerDelta;


    bool _moveToTrunP = true;
    bool _moveToEndP = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       AutoMove();
       IsPlayerMove();

    }

    void AutoMove()
    {
        if (_moveToTrunP)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, TurnPoint, _moveDistancePerDelta);
            if (this.transform.position == TurnPoint)
            {
                _moveToTrunP = false;
                _moveToEndP = !_moveToEndP;
            }
                

        }
        else
        {
            if (_moveToEndP)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, EndPoint, _moveDistancePerDelta);
                if (this.transform.position == EndPoint)
                    _moveToTrunP = true;
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, StartPoint, _moveDistancePerDelta);
                if (this.transform.position == StartPoint)
                    _moveToTrunP = true;
            }      
        }
    }

    void IsPlayerMove()
    {
        if ((this.transform.position.z >=14) && (this.transform.position.x >112))
        {
            if (PlayerController.Instance._rigidbody.velocity.magnitude > 0.15)
                PlayerController.Instance.Exposure += 1;
        }
    }
}
