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
    private Vector3 _startPosition;
    private Vector3 _mePosition;
    private bool _meUp = true;
    public Text TextSubtitle;
    public GameObject DialogPicture;

    public static RunAway Instance;
    private void Awake()
    {
        if (!Instance) Instance = this;
    }

    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 20 * Time.deltaTime, 0);
        if (_meUp)
        {
            _mePosition = new Vector3(_startPosition.x, _startPosition.y +.5f, _startPosition.z);
            transform.position = Vector3.MoveTowards(transform.position, _mePosition, 0.005f);
            
            if(transform.position.y >= _mePosition.y)
                _meUp = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, 0.005f);
            if (transform.position.y <= _startPosition.y)
                _meUp = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "PlayerBall")
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
        _startPosition = _nextPosition;
    }
}
