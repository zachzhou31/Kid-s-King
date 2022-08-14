using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDown : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Table;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Table.transform.localScale.y >5)
            Table.transform.localScale = new Vector3(Table.transform.localScale.x, 1, Table.transform.localScale.z);
    }
}
