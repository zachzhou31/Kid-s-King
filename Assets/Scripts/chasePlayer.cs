using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class chasePlayer : MonoBehaviour
{
    public GameObject Player;
    public float ChaseSpeed = .01f, ShakeTime, ShakeFreequenze;
    public Vector3 ShakeRate = new Vector3(0.1f, 0.1f, 0.1f);

    Vector3 direction;
    Rigidbody _rigidbody;
    bool _shake = false;
    bool _fire = true;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 _playerPosition = Player.transform.position;
        Vector3 _mePostion = transform.position;
        direction = (_playerPosition - _mePostion).normalized;
        if (!_shake)
            Shake();

        if (_shake && _fire)
        {
           _fire = false;
            _rigidbody.AddForce(direction * ChaseSpeed, ForceMode.VelocityChange);
        }
            
        

    }

    void Shake()
    {
        StartCoroutine(Shake_Coroutine());
        _shake = true;
    }

    private IEnumerator Shake_Coroutine()
    {
        Vector3 _mePosition = transform.position;

        for(float i = 0; i < ShakeTime; i += ShakeFreequenze)
        {
            transform.position = _mePosition +
                 Vector3.right * Random.Range(-ShakeRate.x, ShakeRate.x) +
                 Vector3.up * Random.Range(-ShakeRate.y, ShakeRate.y) +
                 Vector3.forward * Random.Range(-ShakeRate.z, ShakeRate.z);
            yield return new WaitForSeconds(ShakeFreequenze);
        }

        transform.position = _mePosition;

    }
}
