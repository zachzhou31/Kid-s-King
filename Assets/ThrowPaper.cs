using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPaper : MonoBehaviour
{
    public GameObject PaperPrefab, ThrowPosition;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        float _randomTime = Random.Range(5, 25);
        if (Timer > _randomTime)
        {
            Throw();
            Timer = 0;
        }
    }

    void Throw()
    {
        Instantiate(PaperPrefab, ThrowPosition.transform.position, PaperPrefab.transform.rotation);
    }
}
