using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherStage2 : MonoBehaviour
{
    public Teacher2 TeacherTwoStatus;
    public Vector3 NewPosition;
    public GameObject BulletPrefab, ShootPosition, StageThreeStart;
    //List of Students, If empty, Teacher gone, Transport to Last Stage.
    public GameObject Student1, Student2, Student3;
    public float ShootWaitTime = 0;


    public List<GameObject> StudentList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StudentList.Add(Student1);
        StudentList.Add(Student2);
        StudentList.Add(Student3);
    }

    // Update is called once per frame
    void Update()
    {
        if (TeacherTwoStatus.TeacherChange2)
        {
            this.GetComponent<TeacherMove>().enabled = false;
            ShootWaitTime += Time.deltaTime;
            if (ShootWaitTime % 10 == 0)
                Shoot();
        }

        
            

    }

    private void Shoot()
    {
        this.transform.position = NewPosition;
        Instantiate(BulletPrefab, ShootPosition.transform.position,BulletPrefab.transform.rotation);
    }

    public void StudentDone()
    {
        StartCoroutine(Wait_Coroutine());
    }

    private IEnumerator Wait_Coroutine()
    {
        yield return new WaitForSeconds(10f);
        Stage3Start();
        Destroy(this);
    }

    private void Stage3Start()
    {
        PlayerController.Instance.transform.position = StageThreeStart.transform.position;
        PlayerController.Instance.JumpForce = 15;
    }
}
