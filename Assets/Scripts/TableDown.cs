using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDown : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Table;

    public GameObject TableCAM;
    public GameObject MoveOutLocation;
    private bool _startDown = false;
    private float t = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_startDown)
        {
            t += Time.deltaTime;
            Table.transform.localScale = new Vector3(Table.transform.localScale.x, Mathf.Lerp(Table.transform.localScale.y, 1,t*0.01f), Table.transform.localScale.z);
            if ((Table.transform.localScale.y) <= 1.01)
            {
                Table.transform.localScale = new Vector3(Table.transform.localScale.x, 1, Table.transform.localScale.z);
                _startDown = false;
                GameObject.Find("PlayerBall").transform.position = MoveOutLocation.transform.position;
                Invoke("CloseCamera", 1.5f);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(Table.transform.localScale.y >= 1)
        {
            TableCAM.SetActive(true);
            _startDown = true;
        }
            
    }

    void CloseCamera()
    {
        TableCAM.SetActive(false);
    }
}
