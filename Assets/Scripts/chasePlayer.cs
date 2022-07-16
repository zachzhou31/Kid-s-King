using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class chasePlayer : MonoBehaviour
{
    //public GameObject Player;
    public float ChaseSpeed = .01f, ShakeTime, ShakeFreequenze;
    public Vector3 ShakeRate = new Vector3(0.1f, 0.1f, 0.1f);
    public float ForceScale = 5;
    //Vector3 direction;
    Rigidbody _rigidbody;
    bool _hasShaken = false;
    //bool _fire = true;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shake()
    {
        _hasShaken = true;
        StartCoroutine(Shake_Coroutine());
    }

    private IEnumerator Shake_Coroutine()
    {
        // Shake
        for(float i = 0; i < ShakeTime; i += ShakeFreequenze)
        {
            var force =
                 Vector3.right * Random.Range(-ShakeRate.x, ShakeRate.x) +
                 Vector3.up * Random.Range(-ShakeRate.y, ShakeRate.y) +
                 Vector3.forward * Random.Range(-ShakeRate.z, ShakeRate.z);

            _rigidbody.velocity = force * ForceScale;
            yield return new WaitForSeconds(ShakeFreequenze);
        }

        // Fire
        Vector3 _playerPosition = PlayerController.Instance.transform.position;
        Vector3 _mePostion = transform.position;
        var direction = (_playerPosition - _mePostion).normalized;
        _rigidbody.AddForce(direction * ChaseSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_hasShaken) Shake();
        if (collision.collider.name == "Player")
            PlayerController.Instance.Exposure = 21;
    }
}
