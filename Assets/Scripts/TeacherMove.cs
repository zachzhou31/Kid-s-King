using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 StartPoint, TurnPoint, EndPoint;
    public float _moveDistancePerDelta;
    public Text SubtitleText;
    public GameObject Dialog;

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
            _moveDistancePerDelta = 0.005f;
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
                _moveDistancePerDelta = 0.005f;
                this.transform.position = Vector3.MoveTowards(this.transform.position, EndPoint, _moveDistancePerDelta);
                if (this.transform.position == EndPoint)
                    _moveToTrunP = true;
            }
            else
            {
                _moveDistancePerDelta = 0.01f;
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
            {
                PlayerController.Instance.Exposure += 1;
                SubtitleText.text = "��ʦ���ˣ��������Ҷ��ˣ���";
                Invoke("Disappear", 3f);
            }
                
        }
    }

    void Disappear()
    {
        Dialog.SetActive(false);
    }
}