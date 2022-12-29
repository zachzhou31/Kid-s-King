using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Table;


    public GameObject TableCAM;
    public GameObject MoveOutLocation;
    private bool _startUp = false;
    private float t = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_startUp)
        {
            t += Time.deltaTime;
            Table.transform.localScale = new Vector3(Table.transform.localScale.x, Mathf.Lerp(Table.transform.localScale.y, 10, t * 0.001f), Table.transform.localScale.z);
            if ((Table.transform.localScale.y) >= 9.99)
            {
                Table.transform.localScale = new Vector3(Table.transform.localScale.x, 10, Table.transform.localScale.z);
                _startUp = false;
                GameObject.Find("PlayerBall").transform.position = MoveOutLocation.transform.position;
                Invoke("CloseCamera", 1.5f);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (Table.transform.localScale.y <= 10)
        {
            TableCAM.SetActive(true);
            _startUp = true;
        }
    }

    void CloseCamera()
    {
        TableCAM.SetActive(false);
    }
}
