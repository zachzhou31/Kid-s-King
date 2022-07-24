using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float Health;
    public float ChaseSpeed;
    public float SpellWaitTime;
    public GameObject BossRound,FakeAttack,StageTwo;

    private bool _attack = false;
    // Start is called before the first frame update
    void Start()
    {
        
        BossRound.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_attack)
            if (Health > 15)
                Invoke("BossAttack",SpellWaitTime);
            else
                Invoke("BossAttackFake", SpellWaitTime/2);


        if(Health <= 0)
        {
            StageTwo.SetActive(true);
            Destroy(this);
            BossRound.SetActive(false);
        }

    }

    private void BossAttack()
    {
        Vector3 _playerPosition = PlayerController.Instance.transform.position;
        Vector3 _mePostion = transform.position;
        var direction = (_playerPosition - _mePostion).normalized;

        this.GetComponent<Rigidbody>().AddForce(direction * ChaseSpeed, ForceMode.Impulse);


    }

    private void BossAttackFake()
    {
        float _randomX = Random.Range(250f, 267f);
        float _randomZ = Random.Range(-213f, -230f);
        Instantiate(FakeAttack, new Vector3(_randomX, this.transform.position.y, _randomZ), FakeAttack.transform.rotation);
        BossAttack();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _attack = true;
    }
}
