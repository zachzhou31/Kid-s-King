using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed;
    public TeacherStage2 TeacherStageTwo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _playerPosition = PlayerController.Instance.transform.position;
        Vector3 _mePostion = transform.position;
        var direction = (_playerPosition - _mePostion).normalized;
        Vector3 _moveDirection = direction * MoveSpeed * Time.deltaTime;
        this.transform.position += _moveDirection;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            PlayerController.Instance.Exposure += 10;
            Destroy(this);
        }
        else if(collision.collider.tag == "Student")
        {
            TeacherStageTwo.StudentList.Remove(collision.collider.gameObject);
            Destroy(collision.collider);
            Destroy(this);
            if (TeacherStageTwo.StudentList.Count == 0)
                TeacherStageTwo.StudentDone();
        }
        else
        {
            Destroy(this);
        }
    }
}
