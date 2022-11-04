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
    public GameObject DialogPicture;
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
        DialogPicture.SetActive(true);
        switch (index) {
            case 0:
                TextSubtitle.text = "不错 现在试着用力弹一下，不过注意别弹太高，落到地上的话……";
                Invoke("Disappear", 4f);
                return Point1.transform.position;
            case 1:
                TextSubtitle.text = "";
                Invoke("Disappear", 4f);
                return Point2.transform.position;
            case 2:
                TextSubtitle.text = "哎哟 不小心摔了一跤 丢远了 要不再过来一下？";
                Invoke("Disappear", 4f);
                return Point3.transform.position;
            case 3:
                TextSubtitle.text = "事不过三 事不过三";
                Invoke("Disappear", 4f);
                return Point4.transform.position;
            default:
                TextSubtitle.text = "继续吧 还差俩个就能见到我咯";
                Invoke("Disappear", 4f);
                WorldManager.Instance.CupCollectCount = 1;
                return Vector3.zero;

        };
        
    }

    void Disappear()
    {
        DialogPicture.SetActive(false);
    }
    private void CupRun()
    {
        this.transform.position = _nextPosition;
    }
}
