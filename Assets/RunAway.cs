using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunAway : MonoBehaviour
{
    public GameObject Point1, Point2, Point3, Point4, Point5;
    // Start is called before the first frame update
    private int _index = 0;
    private Vector3 _nextPosition;
    public Text TextSubtitle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            _nextPosition = this.nextPosition(_index);
            if (_nextPosition != Vector3.zero)
                Invoke("CupRun", 2);
            else
                Destroy(this);
            _index += 1;
        }
            
    }


    public Vector3 nextPosition(int index)
    {
        switch (index) {
            case 0:
                TextSubtitle.text = "���� ��������������һ�£�����ע���̫�ߣ��䵽���ϵĻ�����";
                return Point1.transform.position;
            case 1:
                TextSubtitle.text = "���������������� �����������Ҿ�����Ӯ�";
                return Point2.transform.position;
            case 2:
                TextSubtitle.text = "��Ӵ ��С��ˤ��һ�� ��Զ�� Ҫ���ٹ���һ�£�";
                return Point3.transform.position;
            case 3:
                TextSubtitle.text = "�²����� �²�����";
                return Point4.transform.position;
            case 4:
                TextSubtitle.text = "��ô���׾������ռ�����һ���豭�ˣ���";
                return Point5.transform.position;
            default:
                TextSubtitle.text = "������ �����������ܼ����ҿ�";
                WorldManager.Instance.CupCollectCount += 1;
                return Vector3.zero;

        };

    }

    private void CupRun()
    {
        this.transform.position = _nextPosition;
    }
}
