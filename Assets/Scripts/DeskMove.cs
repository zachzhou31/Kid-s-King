using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 FirstPoint, SecondPoint, ThirdPoint, FourthPoint, FifthPoint;
    public stage1_start StageStartStatus;
    public GameObject Teacher;
    public float MoveDistance;
    public int MoveStep;

 
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            

        if (StageStartStatus.Stage1Start)
            if((Teacher.transform.position.z <= 45.2) &&(Teacher.transform.position.x == -52))
                DeskBounceMove();
        if ((this.transform.position == FirstPoint) || (this.transform.position == SecondPoint) || (this.transform.position == ThirdPoint) || (this.transform.position == FourthPoint) || (this.transform.position == FifthPoint))
        {
            MoveStep += 1;
            if (MoveStep > 5)
                MoveStep = 0;
        }
    }

    void DeskBounceMove()
    {

        switch (MoveStep)
        {
            case 1:
                this.transform.position = Vector3.MoveTowards(this.transform.position, SecondPoint, MoveDistance);
                break;
            case 2:
                this.transform.position = Vector3.MoveTowards(this.transform.position, ThirdPoint, MoveDistance);
                break;
            case 3:
                this.transform.position = Vector3.MoveTowards(this.transform.position, FourthPoint, MoveDistance);
                break;
            case 4:
                this.transform.position = Vector3.MoveTowards(this.transform.position, FifthPoint, MoveDistance);
                break;
            case 5:
                this.transform.position = Vector3.MoveTowards(this.transform.position, FirstPoint, MoveDistance);
                break;
        }


    }
}
