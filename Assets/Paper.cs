using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float _RandomX = Random.Range(-10f, 10f);
        float _RandomY = Random.Range(0, 10f);
        float _RandomZ = Random.Range(-10f, 10f);
        Vector3 RandomV = new Vector3(_RandomX, _RandomY, _RandomZ);
        this.GetComponent<Rigidbody>().AddForce(RandomV * 2, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
