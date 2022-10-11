using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAndBack : MonoBehaviour
{
    public Vector3 StartPoint, EndPoint;
    public GameObject Teacher;
    public float MoveSpeed;
    public stage1_start StageStartStatus;

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
