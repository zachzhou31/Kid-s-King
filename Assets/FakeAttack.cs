using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeAttack : MonoBehaviour
{
    public float ChaseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _playerPosition = PlayerController.Instance.transform.position;
        Vector3 _mePostion = transform.position;
        var direction = (_playerPosition - _mePostion).normalized;

        this.GetComponent<Rigidbody>().AddForce(direction * ChaseSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}
