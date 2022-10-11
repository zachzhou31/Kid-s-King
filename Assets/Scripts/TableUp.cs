using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableUp : MonoBehaviour
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
        if (Table.transform.localScale.y < 17)
            Table.transform.localScale = new Vector3(Table.transform.localScale.x, 10, Table.transform.localScale.z);
    }
}
