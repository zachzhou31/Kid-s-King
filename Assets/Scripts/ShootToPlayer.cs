using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed;

    private Vector3 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _distanceBetween = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
        if(_distanceBetween > 10f){
            Vector3 _playerPosition = PlayerController.Instance.transform.position;
            Vector3 _mePostion = transform.position;
            direction = (_playerPosition - _mePostion).normalized;
            Vector3 _moveDirection = direction * MoveSpeed * Time.deltaTime;
            this.transform.position += _moveDirection;
            direction *= MoveSpeed; // elseÓï¾ä·þÎñ
        }
        else
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            direction -= Vector3.down * -0.98f * Time.deltaTime;
            Vector3 _moveDirection = direction * Time.deltaTime;
            this.transform.position += _moveDirection;
        }


    }
    void Burst()
    {

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
            TeacherStage2.Instance.StudentList.Remove(collision.collider.gameObject);
            Destroy(collision.collider);
            
            if (TeacherStage2.Instance.StudentList.Count == 0)
                TeacherStage2.Instance.StudentDone();
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
