using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAndBack : MonoBehaviour
{
    public Vector3 StartPoint, EndPoint;
    public GameObject Teacher;
    public float MoveSpeed;
    public stage1_start StageStartStatus;

    public Vector3 _direction;
    bool _moveTo = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StageStartStatus.Stage1Start)
            if ((Teacher.transform.position.z <= 45.2) && (Teacher.transform.position.x == -52))
                DeskBounceMove();


    }

    void DeskBounceMove()
    {
        if (_moveTo)
        {
            Vector3 _endPosition = EndPoint;
            Vector3 _mePostion = transform.position;
            _direction = (_endPosition - _mePostion).normalized;
            this.GetComponent<Rigidbody>().MovePosition(transform.position+_direction*MoveSpeed*Time.deltaTime);
            //this.transform.position = Vector3.MoveTowards(this.transform.position, EndPoint, MoveSpeed);
            if (Vector3.Distance(this.transform.position, EndPoint)<1f)
            {
                _moveTo = false;
            }
        }

        else
        {
            Vector3 _endPosition = EndPoint;
            Vector3 _mePostion = transform.position;
            _direction = (_mePostion - _endPosition).normalized;
            this.GetComponent<Rigidbody>().MovePosition(transform.position + _direction * MoveSpeed * Time.deltaTime);
            //this.transform.position = Vector3.MoveTowards(this.transform.position, StartPoint, MoveSpeed);
            if (Vector3.Distance(this.transform.position, StartPoint) < 1f)
            {
                _moveTo = true;
            }
        }
    }
}
