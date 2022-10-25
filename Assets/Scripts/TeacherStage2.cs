using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherStage2 : MonoBehaviour
{
    public Teacher2 TeacherTwoStatus;
    public Vector3 NewPosition;
    public GameObject BulletPrefab, ShootPosition, StageThreeStart;
    //List of Students, If empty, Teacher gone, Transport to Last Stage.
    public GameObject Student1, Student2, Student3;
    public float ShootWaitTime = 0;

    public GameObject Dialog;
    public Text SubtitleText;

    public List<GameObject> StudentList = new List<GameObject>();

    public static TeacherStage2 Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!Instance) Instance = this;
    }

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
            if (ShootWaitTime > 10)
            {
                ShootWaitTime = 0;
                Shoot();
            }
                
        }
        if (StudentList.Count == 0)
            StudentDone();



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
        this.gameObject.SetActive(false);
    }

    private void Stage3Start()
    {
        PlayerController.Instance.transform.position = StageThreeStart.transform.position;
        PlayerController.Instance.JumpForce = 15;
        SubtitleText.text = "老师走了！快去仓库找到他吧";
        Invoke("Disappear", 3f);
    }

    void Disappear()
    {
        Dialog.SetActive(false);
    }
}
