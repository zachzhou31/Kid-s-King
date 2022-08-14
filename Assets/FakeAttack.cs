using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeAttack : MonoBehaviour
{
    public float ChaseSpeed = 5f;

    private bool _fakeAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChaseSpeed = BossMove.Instance.ChaseSpeed;
        if (!_fakeAttack)
        {
            FAttack();
            _fakeAttack = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }

    void FAttack()
    {
        Vector3 _playerPosition = PlayerController.Instance.transform.position;
        Vector3 _mePostion = transform.position;
        var direction = (_playerPosition - _mePostion).normalized;

        this.GetComponent<Rigidbody>().AddForce(direction * ChaseSpeed, ForceMode.Impulse);
    }


}
