using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed;
    public TeacherStage2 TeacherStageTwo;

    private bool _notBurst = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _distanceBetween = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
        if(_distanceBetween > 20f){
            Vector3 _playerPosition = PlayerController.Instance.transform.position;
            Vector3 _mePostion = transform.position;
            var direction = (_playerPosition - _mePostion).normalized;
            Vector3 _moveDirection = direction * MoveSpeed * Time.deltaTime;
            this.transform.position += _moveDirection;
        }
        else
        {
            if (_notBurst)
            {
                _notBurst = false;
                Burst();

            }
                
        }


    }
    void Burst()
    {
        Vector3 _playerPosition = PlayerController.Instance.transform.position;
        Vector3 _mePostion = transform.position;
        var direction = (_playerPosition - _mePostion).normalized;
        Vector3 _moveDirection = direction * MoveSpeed * Time.deltaTime;
        this.transform.position += _moveDirection*2;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            PlayerController.Instance.Exposure += 10;
            Destroy(gameObject);
        }
        else if(collision.collider.tag == "Student")
        {
            TeacherStageTwo.StudentList.Remove(collision.collider.gameObject);
            Destroy(collision.collider);
            
            if (TeacherStageTwo.StudentList.Count == 0)
                TeacherStageTwo.StudentDone();
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
